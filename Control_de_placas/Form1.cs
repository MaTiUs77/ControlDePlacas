using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Control_de_placas
{
    public partial class Form1 : Form
    {
        private formSplash m_Splash;

        public Form1()
        {
            InitializeComponent();
        }

        // Al iniciar la aplicacion, verifica actualizaciones, y muestra el splash de login.
        private void Form1_Load(object sender, EventArgs e)
        {
            Aplicacion.update();

            Aplicacion.formMain = this;
            this.Enabled = false;
            this.m_Splash = new formSplash();
            this.m_Splash.Owner = this;
            this.m_Splash.ShowDialog();
            Application.DoEvents();
        }
     
        // Cierra splash e inicio aplicacion
        public void finalizarLogin()
        {
            m_Splash.Close();
            startMain();
        }

        // Muestro/Oculto opciones segun permiso de usuario
        public void startMain()
        {
            hideDeclaracionBox();
            toggleAvailableOptions();
            reloadMainGrid();
            fillStatusBar();            
        }

        #region FORM UI

        /// <summary>
        /// Esconder box de declaracion
        /// </summary>
        private void hideDeclaracionBox()
        {
            iniPanel.RowStyles[0].Height = 0;
        }

        /// <summary>
        /// Muestra u oculta opciones disponibles segun el tipo de acceso del Operador autenticado
        /// </summary>
        private void toggleAvailableOptions()
        {
            if (Operador.acceso.Equals("A"))
            {
                administracionMenuItem.Visible = true;
                enviarOPMenuItem.Visible = true;
            }
            else
            {
                reprocesoMenuItem.Visible = false;

                recepcionarMenuItem.Enabled = false;
                recepcionarMenuItem.Visible = false;

                reprocesoMenuItem_solicitar.Visible = false;
                reprocesoMenuItem_enviar.Visible = false;

                if (Operador.acceso.Equals("O"))
                {
                    reprocesoMenuItem.Visible = true;
                    reprocesoMenuItem_enviar.Visible = true;
                    enviarOPMenuItem.Visible = true;
                }
                else
                {
                    if (Operador.acceso.Equals("R"))
                    {
                        reprocesoMenuItem.Visible = true;
                        reprocesoMenuItem_solicitar.Visible = true;

                        recepcionarMenuItem.Enabled = true;
                        recepcionarMenuItem.Visible = true;
                    }
                }
                if (
                    Operador.acceso.Equals("I") ||
                    Operador.acceso.Equals("R")
                    )
                {
                    _cargado.Visible = false;

                    lotesMenuItem.Visible = false;
                    mainTab.TabPages.Remove(tabEstadisticas);
                }
            }
        }

        /// <summary>
        /// Completa la barra inferior con datos de turno, operador y sector
        /// </summary>
        private void fillStatusBar()
        {
            // Datos en status.
            status_operador.Text = Operador.operador;
            if (Operador.turno.Equals("0"))
            {
                status_turno.Visible = false;
                status_turno_label.Visible = false;
            }
            else
            {
                status_turno.Text = Operador.turno;
            }
            status_servidor.Text = Operador.servidor;
        }

        /// <summary>
        /// Helper, en caso de no poder convertir el string a int, este es null
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public int? ParseToNull(string categoryId)
        {
            int id;
            return int.TryParse(categoryId, out id) ? (int?)id : null;
        }
        #endregion

        #region MAINGRID UI

        /// <summary>
        /// Recarga tanto los datos de envios como de recepciones segun el filtro aplicado
        /// </summary>
        public void reloadMainGrid()
        {
            cargarDevoluciones();

            mainGrid.Rows.Clear();

            Mysql sql = new Mysql();

            DataTable dt = sql.Select(Consulta.Principal(Filtro.aplicar(Filtro.main)));

            //            Bitmap mensajeado;
            Bitmap recepcion;

            foreach (DataRow d in dt.Rows)
            {
                int? restantes = ParseToNull(d["restantes"].ToString());
                int? cantidad = ParseToNull(d["cantidad"].ToString());
                int? salidas = ParseToNull(d["salidas"].ToString());
                int? total = ParseToNull(d["total"].ToString());

                int? notas = ParseToNull(d["notas"].ToString());

                recepcion = Recepcion.icono(d["recepcion_flag"].ToString());

                int r = mainGrid.Rows.Add(
                    d["ebs"].ToString(),
                    d["id"].ToString(),
                    "",
                    d["op"].ToString(),
                    d["stocker"].ToString(),
                    d["semielaborado"].ToString(),
                    d["modelo"].ToString(),
                    d["lote"].ToString(),
                    d["placa"].ToString(),
                    cantidad,
                    salidas,
                    total,
                    restantes,
                    d["fecha"].ToString(),
                    d["hora"].ToString(),
                    Global.normalizarTurno(d["turno"].ToString()) + " (" + d["por_turno"].ToString() + ")",
                    d["notas"].ToString(),
                    d["destino"].ToString(),
                    d["recepcion_operador"].ToString(),
                    d["recepcion_fecha"].ToString(),
                    recepcion,
                    d["transaccion"].ToString()
                    );
                Global.mainGrid_colour(mainGrid.Rows[r], restantes.ToString());

                if (!d["notas"].ToString().Equals(""))
                {
                    mainGrid.Rows[r].Cells["_notas"] = new DataGridViewImageCell();
                    mainGrid.Rows[r].Cells["_notas"].Value = Properties.Resources.notas;
                    mainGrid.Rows[r].Cells["_notas"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }

        /// <summary>
        /// Aplica el filtro solicitado segun el TAB actual, envios o reprocesos
        /// </summary>
        /// <param name="filtro"></param>
        public void aplicarFiltro(Filtro filtro)
        {
            if (Aplicacion.currentTab == 0)
            {
                Filtro.main.id = "";
                Filtro.main.modelo = filtro.modelo;
                Filtro.main.lote = filtro.lote;
                Filtro.main.placa = filtro.placa;
                Filtro.main.desde = filtro.desde;
                Filtro.main.hasta = filtro.hasta;
                Filtro.main.id_destino = filtro.id_destino;
                Filtro.main.recepcion = filtro.recepcion;
                Filtro.main.ebs = filtro.ebs;
                Filtro.main.op = filtro.op;

                reloadMainGrid();
            }
            else
            {
                Filtro.reproceso.id = "";
                Filtro.reproceso.modelo = filtro.modelo;
                Filtro.reproceso.lote = filtro.lote;
                Filtro.reproceso.placa = filtro.placa;
                Filtro.reproceso.desde = filtro.desde;
                Filtro.reproceso.hasta = filtro.hasta;
                Filtro.reproceso.id_destino = filtro.id_destino;
                Filtro.reproceso.recepcion = filtro.recepcion;
                Filtro.reproceso.ebs = filtro.ebs;
                Filtro.reproceso.op = filtro.op;
                Filtro.reproceso.id_solicitante = filtro.id_solicitante;

                cargarDevoluciones();
            }
        }

        public void cargarDevoluciones()
        {

            Reproceso rep = new Reproceso();
            rep.CargarMain(gridDevolucion);
        }

        private void mainGrid_MouseUp(object sender, MouseEventArgs e)
        {
            int row = mainGrid.HitTest(e.X, e.Y).RowIndex;
            int col = mainGrid.HitTest(e.X, e.Y).ColumnIndex;

            Aplicacion.currentMainID = row;
            Aplicacion.currentDatoID = null;

            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();

                if (row >= 0 && col >= 0)
                {
                    DataGridViewRow r = mainGrid.Rows[row];

                    Aplicacion.currentMainID = row;
                    Aplicacion.currentDatoID = r.Cells["_id"].Value.ToString();

                    string modelo = r.Cells["_modelo"].Value.ToString();
                    string lote = r.Cells["_lote"].Value.ToString();
                    string placa = r.Cells["_placa"].Value.ToString();
                    string cantidad = r.Cells["_cantidad"].Value.ToString();

                    string destino = r.Cells["_destino"].Value.ToString();

                    mainGrid.ClearSelection();
                    r.Cells[col].Selected = true;

                    if (!Operador.acceso.Equals("I") && !Operador.acceso.Equals("R"))
                    {
                        m.MenuItems.Add(new MenuItem("Reporte general", mainGrid_btReporte));
                        m.MenuItems.Add(new MenuItem("-"));
                    }

                    MenuItem Filtro = new MenuItem("Aplicar filtro");
                    Filtro.MenuItems.Add(new MenuItem("Nuevo filtro", mainGrid_btFiltroNew));
                    Filtro.MenuItems.Add("-");

                    MenuItem filtro_modelo_lote_placa = new MenuItem("Filtrar: " + modelo + " - " + lote + " - " + placa, mainGrid_btFiltro1);
                    Filtro.MenuItems.Add(filtro_modelo_lote_placa);
                    Filtro.MenuItems.Add(new MenuItem("Filtrar: " + modelo + " - " + lote, mainGrid_btFiltro2));
                    Filtro.MenuItems.Add(new MenuItem("Filtrar: " + modelo + " - " + placa, mainGrid_btFiltro4));
                    Filtro.MenuItems.Add(new MenuItem("Filtrar: " + modelo, mainGrid_btFiltro3));

                    m.MenuItems.Add(Filtro);

                    m.MenuItems.Add(new MenuItem("-"));
                    m.MenuItems.Add(new MenuItem("Notas", mainGrid_btNotas));

                    if (
                        Operador.acceso == "A" ||
                        Operador.acceso.Equals("O")
                       )
                    {
                        m.MenuItems.Add(new MenuItem("-"));
                        m.MenuItems.Add(new MenuItem("Imprimir Salida", imprimir_salida));
                    }

                    if (
                        Operador.acceso == "A" ||
                        Operador.acceso == "SP"
                        )
                    {
                        m.MenuItems.Add(new MenuItem("-"));
                        m.MenuItems.Add(new MenuItem("Borrar", mainGrid_btBorrar));
                    }

                    if (
                         (Operador.sector == destino || destino == "") &&
                         (Operador.acceso == "A" || Operador.acceso == "R")
                        )
                    {
                        m.MenuItems.Add(new MenuItem("-"));
                        MenuItem recepcion_menu = new MenuItem("Recepcion");
                        MenuItem menutitulo = new MenuItem(modelo + " - " + lote + " - " + placa);
                        menutitulo.Enabled = false;
                        recepcion_menu.MenuItems.Add(menutitulo);
                        recepcion_menu.MenuItems.Add(new MenuItem("-"));
                        recepcion_menu.MenuItems.Add(new MenuItem("Completo: " + cantidad, recepcion_estado_completo));
                        recepcion_menu.MenuItems.Add(new MenuItem("Incompleto", recepcion_estado_incompleto));
                        recepcion_menu.MenuItems.Add(new MenuItem("-"));
                        recepcion_menu.MenuItems.Add(new MenuItem("Pendiente", recepcion_estado_pendiente));

                        m.MenuItems.Add(recepcion_menu);
                    }
                }
                else
                {
                    m.MenuItems.Add(new MenuItem("Aplicar filtro", mainGrid_btFiltroNew));
                }

                m.Show(mainGrid, new Point(e.X, e.Y));
            }
            else if ((e.Button == MouseButtons.Left) && (row >= 0))
            {
                DataGridViewRow r = mainGrid.Rows[row];

                Aplicacion.currentMainID = row;
                Aplicacion.currentDatoID = r.Cells["_id"].Value.ToString();

                switch (col)
                {
                    case 0: // Cargado

                        if (Operador.acceso.Equals("O"))
                        {
                            if (Convert.ToBoolean(r.Cells["_cargado"].Value) == true)
                            {
                                bool upd = updateCargado(Aplicacion.currentDatoID, 0);
                                if (upd)
                                {
                                    r.Cells["_cargado"].Value = false;
                                }
                            }
                            else
                            {
                                bool upd = updateCargado(Aplicacion.currentDatoID, 1);
                                if (upd)
                                {
                                    r.Cells["_cargado"].Value = true;
                                }
                            }
                        }
                        break;
                }

            }
        }

        private void mainGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int col = e.ColumnIndex;
            int row = e.RowIndex;

            DataGridViewRow r = mainGrid.Rows[row];

            string id = r.Cells["_id"].Value.ToString();

            gridNotas.Rows.Clear();

            if (!r.Cells["_notas"].Value.Equals(""))
            {
                reloadNotas(id, "");
            }
        }
        #endregion

        #region MAINGRID CONTEXT MENU
        public bool updateCargado(string id, int estado)
        {
            Mysql sql = new Mysql();
            bool rs = sql.Ejecutar("update datos set ebs = '" + estado + "' where id = '" + id + "' limit 1");
            if (!rs)
            {
                MessageBox.Show("updateCargado(): Error al guardar cambio de estado en Base de Datos.");
                return false;
            }
            return true;
        }

        private void mainGrid_btNotas(object sender, EventArgs e)
        {
            redactarNota(Aplicacion.currentDatoID, "N");
        }

        private void mainGrid_btReporte(object sender, EventArgs e)
        {
            mainTab.SelectTab(tabEstadisticas);
            string modelo = mainGrid.Rows[Aplicacion.currentMainID].Cells["_modelo"].Value.ToString();
            webBrowser1.Url = new Uri("http://10.30.10.22/controldeplacas/?modelo="+modelo);
        }

        private void redactarNota(string id_dato, string flag)
        {
            if (Aplicacion.formNotas == null)
            {
                formNotas fmNotas = new formNotas();
                fmNotas.id_dato = id_dato;
                fmNotas.flag = flag;
                fmNotas.Show();
            }
            else
            {
                Aplicacion.formNotas.Select();
                Aplicacion.formNotas.id_dato = id_dato;
                Aplicacion.formNotas.flag = flag;
            }
        }

        private void mainGrid_btBorrar(object sender, EventArgs args)
        {
            if (MessageBox.Show("Confirma eliminacion?", "Borrar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string sqlString = "delete from datos where id = '" + Aplicacion.currentDatoID + "' limit 1";

                Mysql sql = new Mysql();
                bool rs = sql.Ejecutar(sqlString);
                if (rs)
                {
                    reloadMainGrid();
                }
                else
                {
                    MessageBox.Show("mainGrid_btBorrar(): Error al borrar.");
                }
            }
        }
        #endregion

        #region MAINGRID CONTEXT MENU FILTRO
        private void mainGrid_btFiltro1(object sender, EventArgs e)
        {
            DataGridViewRow r = mainGrid.Rows[Aplicacion.currentMainID];

            string modelo = r.Cells["_modelo"].Value.ToString();
            string lote = r.Cells["_lote"].Value.ToString();
            string placa = r.Cells["_placa"].Value.ToString();

            formFiltro ff = new formFiltro(this);
            ff.filtro.modelo = modelo;
            ff.filtro.lote = lote;
            ff.filtro.placa = placa;
            ff.Show();
        }

        private void mainGrid_btFiltro2(object sender, EventArgs e)
        {
            DataGridViewRow r = mainGrid.Rows[Aplicacion.currentMainID];

            string modelo = r.Cells["_modelo"].Value.ToString();
            string lote = r.Cells["_lote"].Value.ToString();

            formFiltro ff = new formFiltro(this);
            ff.filtro.modelo = modelo;
            ff.filtro.lote = lote;
            ff.Show();
        }

        private void mainGrid_btFiltro3(object sender, EventArgs e)
        {
            DataGridViewRow r = mainGrid.Rows[Aplicacion.currentMainID];

            string modelo = r.Cells["_modelo"].Value.ToString();

            formFiltro ff = new formFiltro(this);
            ff.filtro.modelo = modelo;
            ff.Show();
        }

        private void mainGrid_btFiltro4(object sender, EventArgs e)
        {
            DataGridViewRow r = mainGrid.Rows[Aplicacion.currentMainID];

            string modelo = r.Cells["_modelo"].Value.ToString();
            string placa = r.Cells["_placa"].Value.ToString();

            formFiltro ff = new formFiltro(this);
            ff.filtro.modelo = modelo;
            ff.filtro.placa = placa;
            ff.Show();
        }

        private void mainGrid_btFiltroNew(object sender, EventArgs e)
        {
            formFiltro nt = new formFiltro(this);
            nt.Show();
        }
        #endregion

        public void imprimir_salida(object sender, EventArgs e)
        {
            string codigo = Aplicacion.currentDatoID;
            DataGridViewRow r = mainGrid.Rows[Aplicacion.currentMainID];

            string modelo = r.Cells["_modelo"].Value.ToString();
            string lote = r.Cells["_lote"].Value.ToString();
            string placa = r.Cells["_placa"].Value.ToString();
            string cantidad = r.Cells["_cantidad"].Value.ToString();
            string op = r.Cells["_op"].Value.ToString();
            string semielaborado = r.Cells["_semielaborado"].Value.ToString();

            string destino = r.Cells["_destino"].Value.ToString();

            string fecha = r.Cells["_fecha"].Value.ToString();
            string hora = r.Cells["_hora"].Value.ToString();

            if (destino.Equals(""))
            {
                destino = "...............";
//                MessageBox.Show("No es posible imprimir un pedido si no se asigno un destino!");
            }
 //           else
  //          {
                ImprimirPedido s = new ImprimirPedido();
                s.modelo = modelo;
                s.lote = lote;
                s.panel = placa;
                s.cantidad = cantidad;
                s.op = op;
                s.semielaborado = semielaborado;

                s.codigo = codigo;
                s.fecha = fecha;
                s.hora = hora;

                s.destino = destino;

                s.Imprimir();
    //        }
        }

        public void reloadNotas(string id_dato, string flag)
        {

            gridNotas.Rows.Clear();

            Mysql sql = new Mysql();
            string sqlString = @"
                SELECT o.operador,id_dato,nota, DATE_FORMAT(fecha, '%d/%m/%Y') as fecha, DATE_FORMAT(hora, '%H:%i') as hora FROM `notas` 

                left join
                (
                select id,operador from operadores 
                ) as o
                on o.id = id_operador

                where id_dato = '" + id_dato + "' ";
            //AND flag = '"+flag+"'
            /*
                        if (!id_dato.Equals(""))
                        {
                            sqlString += " and id_dato = '" + id_dato + "' ";
                        }
            */
            DataTable dt = sql.Select(sqlString);

            foreach (DataRow row in dt.Rows)
            {
                gridNotas.Rows.Add(
                    row["id_dato"].ToString(),
                    row["operador"].ToString(),
                    row["nota"].ToString(),
                    row["fecha"].ToString(),
                    row["hora"].ToString()
                );
            }
        }

        #region RECEPCION GRID
        private void recepcion_grid_update(string operador, string fecha, Bitmap flag)
        {
            DataGridViewRow r = mainGrid.Rows[Aplicacion.currentMainID];
            r.Cells["_Recepcion"].Value = operador;
            r.Cells["_Fecha_de_recepcion"].Value = fecha;
            r.Cells["_Recepcion_flag"].Value = flag;
        }

        private void recepcion_estado_completo(object sender, EventArgs e)
        {
            Recepcion rp = new Recepcion();
            rp.id_dato = Aplicacion.currentDatoID;
            rp.nflag = "Y";
            rp.actualizar = true;
            bool rs = rp.Agregar();
            if (rs)
            {
                int find_row = findRow(rp.id_dato);
                if (find_row >= 0)
                {
                    Aplicacion.currentMainID = find_row;
                    recepcion_grid_update(Operador.operador, rp.curr_fecha, Properties.Resources.rec_si);
                }
                else
                {
                    Filtro.limpiarMain();
                    Filtro.main.id = rp.id_dato;
                    reloadMainGrid();
                }
            }
        }

        private void recepcion_estado_incompleto(object sender, EventArgs e)
        {
            Recepcion rp = new Recepcion();
            rp.id_dato = Aplicacion.currentDatoID;
            rp.actualizar = true;
            rp.nflag = "N";
            bool rs = rp.Agregar();

            if (rs)
            {
                MessageBox.Show("Por favor, redacte la disconformidad");
                redactarNota(Aplicacion.currentDatoID, "R");


                int find_row = findRow(rp.id_dato);
                if (find_row >= 0)
                {
                    Aplicacion.currentMainID = find_row;
                    recepcion_grid_update(Operador.operador, rp.curr_fecha, Properties.Resources.rec_no);
                }
                else
                {
                    Filtro.limpiarMain();
                    Filtro.main.id = rp.id_dato;
                    reloadMainGrid();
                }
            }
        }

        private void recepcion_estado_pendiente(object sender, EventArgs e)
        {
            Recepcion rp = new Recepcion();
            rp.id_dato = Aplicacion.currentDatoID;
            bool rs = rp.Eliminar();

            if (rs)
            {
                int find_row = findRow(rp.id_dato);
                if (find_row >= 0)
                {
                    Aplicacion.currentMainID = find_row;
                    recepcion_grid_update("", "", Properties.Resources.rec_pen);
                }
                else
                {
                    Filtro.limpiarMain();
                    Filtro.main.id = rp.id_dato;
                    reloadMainGrid();
                }
            }
            else
            {
                MessageBox.Show("Ocurrio un error al realizar la accion, intente mas tarde.");
            }
        }

        private int findRow(string id) {
            int index = -1;

            IEnumerable<DataGridViewRow> row = mainGrid.Rows.Cast<DataGridViewRow>();
            DataGridViewRow rt = row.Where(r => r.Cells["_id"].Value.ToString().Equals(id)).FirstOrDefault();
            if (rt != null)
            {
                index = rt.Index;
            }
            return index;
        }
        
        private void mainReproceso_mouseUp(object sender, MouseEventArgs e)
        {
            DataGridView grid = gridDevolucion;

            int row = grid.HitTest(e.X, e.Y).RowIndex;
            int col = grid.HitTest(e.X, e.Y).ColumnIndex;

            Reproceso.gridId = null;
            Reproceso.gridRow = row;

            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();

                if (row >= 0 && col >= 0)
                {
                    DataGridViewRow r = grid.Rows[row];

                    Reproceso.gridRow = row;
                    Reproceso.gridId = r.Cells["r_id"].Value.ToString();

                    string solicitante = r.Cells["r_solicitante"].Value.ToString();

                    string reenvio = r.Cells["r_fechareenvio"].Value.ToString();
                    string ingreso = r.Cells["r_fechaingreso"].Value.ToString();
                    string recepcionado = r.Cells["r_fecharecepcion"].Value.ToString();

                    string modelo = r.Cells["r_modelo"].Value.ToString();
                    string lote = r.Cells["r_lote"].Value.ToString();
                    string placa = r.Cells["r_placa"].Value.ToString();

                    string cantidad = r.Cells["r_cantidad"].Value.ToString();

                    grid.ClearSelection();
                    r.Cells[col].Selected = true;

                    if (Operador.acceso == "O")
                    {

                        MenuItem menutitulo = new MenuItem(modelo + " - " + lote + " - " + placa);                        
                        menutitulo.Enabled = false;
                        m.MenuItems.Add(menutitulo);

                        if (ingreso.Equals(""))
                        {
                            m.MenuItems.Add(new MenuItem("-"));
                            m.MenuItems.Add(new MenuItem("Recepcionar: " + cantidad, recepcionarCompletoContextMenu));
                        }
                        else
                        {
                            if (!reenvio.Equals(""))
                            {
                                m.MenuItems.Add(new MenuItem("-"));
                                m.MenuItems.Add(new MenuItem("Imprimir reenvio", ImprimirReEnvio));
                            }
                            else
                            {
                                m.MenuItems.Add(new MenuItem("-"));
                                m.MenuItems.Add(new MenuItem("Enviar: " + cantidad, reenviarContextMenu));
                            }
                        }
                       
                    }

                    if (
                            Operador.acceso == "A" ||
                            (
                                Operador.acceso == "R" &&
                                Operador.sector == solicitante
                            )
                      )
                    {
                        m.MenuItems.Add(new MenuItem("Imprimir Salida", ImprimirDevolucion));

                        if (Operador.acceso == "A" || ingreso.Equals(""))
                        {
                            m.MenuItems.Add(new MenuItem("-"));
                            m.MenuItems.Add(new MenuItem("Borrar", BorrarReproceso));
                        }

                        if (!reenvio.Equals(""))
                        {
                            m.MenuItems.Add(new MenuItem("-"));
                            MenuItem recepcion_menu = new MenuItem("Recepcion");
                            MenuItem menutitulo = new MenuItem(modelo + " - " + lote + " - " + placa);
                            menutitulo.Enabled = false;
                            recepcion_menu.MenuItems.Add(menutitulo);

                            recepcion_menu.MenuItems.Add(new MenuItem("-"));
                            if (recepcionado.Equals(""))
                            {
                                recepcion_menu.MenuItems.Add(new MenuItem("Completo: " + cantidad, recepcionarCompletoContextMenu));
                            }
                            recepcion_menu.MenuItems.Add(new MenuItem("Incompleto", recepcionarIncompletoContextMenu));
                            recepcion_menu.MenuItems.Add(new MenuItem("-"));
                            recepcion_menu.MenuItems.Add(new MenuItem("Pendiente", recepcionarPendienteContextMenu));

                            m.MenuItems.Add(recepcion_menu);
                        }
                    }
                }
                m.Show(grid, new Point(e.X, e.Y));
            }
        }

        private void recepcionarCompletoContextMenu(object sender, EventArgs e)
        {
            Reproceso.flag = "Y";
            iniciarReproceso();
        }

        private void recepcionarIncompletoContextMenu(object sender, EventArgs e)
        {
            Reproceso.flag = "N";
            iniciarReproceso();
        }

        private void recepcionarPendienteContextMenu(object sender, EventArgs e)
        {
            Reproceso.flag = "N";
            Reproceso rp = new Reproceso();
            string codigo = Reproceso.gridId;
            rp.SetPendiente(codigo);
            cargarDevoluciones();
        }        

        public void iniciarReproceso()
        {
            string codigo = Reproceso.gridId;

            if (codigo == null)
            {
                Scan sc = new Scan();
                sc.ShowDialog();
                codigo = sc.codigo;
            }

            if (!codigo.Equals(""))
            {
                Reproceso rp = new Reproceso();

                if (Operador.acceso.Equals("O"))
                {
                    rp.RecepcionarSolicitud(codigo);
                }
                else
                {   
                    DataGridViewRow r = gridDevolucion.Rows[Reproceso.gridRow];

                    string solicitante = r.Cells["r_solicitante"].Value.ToString();


                    if (Operador.acceso.Equals("R") && solicitante.Equals(Operador.sector))
                    {
                        rp.ConfirmarEnvio(codigo);
                    }
                }

                mainTab.SelectTab(tabReproceso);
                cargarDevoluciones();
            }
        }

        public void reenviarContextMenu(object sender, EventArgs e)
        {
            reenviarReproceso();
        }

        public void reenviarReproceso() {
            string codigo = Reproceso.gridId;

            if (codigo == null)
            {
                Scan sc = new Scan();
                sc.ShowDialog();
                codigo = sc.codigo;
            }

            if (!codigo.Equals(""))
            {
                Reproceso rp = new Reproceso();
                rp.EnviarSolicitud(codigo);

                mainTab.SelectTab(tabReproceso);
                cargarDevoluciones();
            }        
        }

        // Borrar Reproceso 
        public void BorrarReproceso(object sender, EventArgs e)
        {
            string codigo = Reproceso.gridId;
            DataGridViewRow r = gridDevolucion.Rows[Reproceso.gridRow];

            if (MessageBox.Show("Confirma eliminacion?", "Borrar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string sqlString = "delete from reproceso where id = '" + codigo + "' limit 1";

                Mysql sql = new Mysql();
                bool rs = sql.Ejecutar(sqlString);
                if (rs)
                {
                    cargarDevoluciones();
                }
                else
                {
                    MessageBox.Show("Error al borrar.");
                }
            }
        }
        // Imprimir Reenvio
        public void ImprimirReEnvio(object sender, EventArgs e)
        {
            string codigo = Reproceso.gridId;
            DataGridViewRow r = gridDevolucion.Rows[Reproceso.gridRow];

            string modelo = r.Cells["r_modelo"].Value.ToString();
            string lote = r.Cells["r_lote"].Value.ToString();
            string placa = r.Cells["r_placa"].Value.ToString();
            string cantidad = r.Cells["r_cantidad"].Value.ToString();

            string destino = r.Cells["r_destino"].Value.ToString();
            string solicitud = r.Cells["r_solicitante"].Value.ToString();

            string fecha = r.Cells["r_fecha"].Value.ToString();
            string hora = r.Cells["r_hora"].Value.ToString();

            if (destino.Equals(""))
            {
                destino = "...............";

            }
            ImprimirPedido s = new ImprimirPedido();
            s.modelo = modelo;
            s.lote = lote;
            s.panel = placa;
            s.cantidad = cantidad;

            s.codigo = codigo;
            s.fecha = fecha;
            s.hora = hora;

            s.destino = solicitud;
            s.reenvio = solicitud;
//            s.previa = true;

            s.Imprimir();
        }
        // Imprimir Devolucion
        public void ImprimirDevolucion(object sender, EventArgs e)
        {
            string codigo = Reproceso.gridId;
            DataGridViewRow r = gridDevolucion.Rows[Reproceso.gridRow];

            string modelo = r.Cells["r_modelo"].Value.ToString();
            string lote = r.Cells["r_lote"].Value.ToString();
            string placa = r.Cells["r_placa"].Value.ToString();
            string cantidad = r.Cells["r_cantidad"].Value.ToString();

            string destino = r.Cells["r_destino"].Value.ToString();
            string solicitud = r.Cells["r_solicitante"].Value.ToString();

            string fecha = r.Cells["r_fecha"].Value.ToString();
            string hora = r.Cells["r_hora"].Value.ToString();

            if (destino.Equals(""))
            {
                destino = "...............";
               
            }
            ImprimirPedido s = new ImprimirPedido();
            s.modelo = modelo;
            s.lote = lote;
            s.panel = placa;
            s.cantidad = cantidad;
            s.reproceso = solicitud;

            s.codigo = codigo;
            s.fecha = fecha;
            s.hora = hora;

            s.destino = destino;

            //s.previa = true;

            s.Imprimir();
        }
        #endregion

        #region MENU ITEM CLICK
        private void refrescarMenuItem_Click(object sender, EventArgs e)
        {
            reloadMainGrid();
        }

        private void paletizarMenuItem_Click(object sender, EventArgs e)
        {
            formPaletizarOpen();
        }

        private void filtroMenuItem_nuevo_Click(object sender, EventArgs e)
        {
            mainGrid_btFiltroNew(sender, e);
        }

        private void filtroMenuItem_codigo_Click(object sender, EventArgs e)
        {
            formFiltroCodigo();
        }

        private void filtroMenuItem_quitar_Click(object sender, EventArgs e)
        {
            actionFiltroQuitar();
        }

        private void recepcionarMenuItem_Click(object sender, EventArgs e)
        {
            formRecepcionar();
        }

        private void lotesMenuItem_Click(object sender, EventArgs e)
        {
            formLotes();
        }

        private void reprocesoMenuItem_solicitar_Click(object sender, EventArgs e)
        {
            formReprocesoSolicitar();
        }

        private void reprocesoMenuItem_recepcionar_Click(object sender, EventArgs e)
        {
            Reproceso.gridId = null;
            Reproceso.flag = "Y";
            iniciarReproceso();
        }

        private void reprocesoMenuItem_enviar_Click(object sender, EventArgs e)
        {
            Reproceso.gridId = null;
            reenviarReproceso();
        }

        public void configuracionMenuItem_Click(object sender, EventArgs e)
        {
            if (Aplicacion.formConfig == null)
            {
                formConfig fm = new formConfig();
                fm.Show();
            }
            else
            {
                Aplicacion.formConfig.Select();
            }
        }

        private void acercaDeMenuItem_Click(object sender, EventArgs e)
        {
            formAcercade fm = new formAcercade();
            fm.ShowDialog();
        }
        #endregion

        #region FORMS y ACTIONS
        private void formPaletizarOpen()
        {
            formPaletizar sr = new formPaletizar(this);
            sr.ShowDialog();
        }

        private void formRecepcionar()
        {
            Scan sc = new Scan();
            sc.ShowDialog();

            if (!sc.codigo.Equals(""))
            {
                Recepcion rp = new Recepcion();
                rp.id_dato = sc.codigo;
                rp.nflag = "Y";
                bool rs = rp.Agregar();
                if (rs)
                {
                    int find_row = findRow(sc.codigo);
                    if (find_row >= 0)
                    {
                        Aplicacion.currentMainID = find_row;
                        recepcion_grid_update(Operador.operador, rp.curr_fecha, Properties.Resources.rec_si);
                    }
                    else
                    {
                        Filtro.limpiarMain();
                        Filtro.main.id = sc.codigo;
                        reloadMainGrid();
                    }
                }
            }
        }

        private void formLotes()
        {
            if (Aplicacion.formLotes == null)
            {
                formLotes fm = new formLotes();
                fm.Show();
            }
            else
            {
                Aplicacion.formLotes.Select();
            }
        }

        private void formFiltroCodigo()
        {
            Scan sc = new Scan();
            sc.ShowDialog();
            if (!sc.codigo.Equals(""))
            {
                Filtro.main.id = sc.codigo;
                reloadMainGrid();
            }
        }

        private void actionFiltroQuitar()
        {
            if (Aplicacion.currentTab == 0)
            {
                Filtro.limpiarMain();
                reloadMainGrid();
            }
            if (Aplicacion.currentTab == 1)
            {
                Filtro.limpiarReproceso();
                cargarDevoluciones();
            }
        }

        private void formReprocesoSolicitar()
        {
            formSolicitarReproceso sr = new formSolicitarReproceso();
            sr.ShowDialog();

            string modelo = sr.modelo;
            string lote = sr.lote;
            string panel = sr.panel;
            string cantidad = sr.cantidad;
            string destino = sr.destino;

            if (sr.completo)
            {
                Reproceso rp = new Reproceso();

                rp.AgregarSolicitud(destino, modelo, lote, panel, cantidad);

                mainTab.SelectTab(tabReproceso);
                cargarDevoluciones();
            }
        }

        #endregion

        private void mainTab_IndexChanged(object sender, EventArgs e)
        {
            TabControl tb = (TabControl)sender;
            Aplicacion.currentTab = tb.SelectedIndex;
            gridNotas.Rows.Clear();
        }

        private void enviarOpMenuItem_Click(object sender, EventArgs e)
        {
            formEnviarOp sr = new formEnviarOp(this);
            sr.ShowDialog();
        }
    }
}

