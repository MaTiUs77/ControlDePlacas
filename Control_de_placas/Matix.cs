using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using DataMatrix.net;

namespace Control_de_placas
{
    class MatrixCode
    {
        public Bitmap make(string sValue, int iBitSize, int iBorSize)
        {
            sValue = sValue.Replace("[ENTER]",System.Environment.NewLine);
            DmtxImageEncoder encoder = new DmtxImageEncoder();
            DmtxImageEncoderOptions options = new DmtxImageEncoderOptions();
            options.ModuleSize = iBitSize;
            options.MarginSize = iBorSize;
            options.BackColor = System.Drawing.Color.White;
            options.ForeColor = System.Drawing.Color.Black;
            Bitmap oB = encoder.EncodeImage(sValue, options);
            return oB;
        }
    }
}
