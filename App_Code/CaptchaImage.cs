using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;

public class CaptchaImage
{
    public string Text
    {
        get { return this.text; }
    }
    public Color BackgroundColor
    {
        get { return this.bc; }
    }
    public Bitmap Image
    {
        get { return this.image; }
    }
    public int Width
    {
        get { return this.width; }
    }
    public int Height
    {
        get { return this.height; }
    }

    private string text;
    private Color bc;
    private int width;
    private int height;
    private Bitmap image;

    public CaptchaImage(string s, Color bc, int width, int height)
    {
        this.text = s;
        this.bc = bc;
        this.width = width;
        this.height = height;
        this.GenerateImage();
    }

    ~CaptchaImage()
    {
        Dispose(false);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        this.Dispose(true);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
            this.image.Dispose();
    }
    private FontFamily[] fonts = {
            new FontFamily("Times New Roman"),
            new FontFamily("Georgia"),
            new FontFamily("Arial"),
            new FontFamily("Comic Sans MS")
        };
    private Color GetColor(int rnd)
    {
        switch (rnd)
        {
            case 0: return Color.Red;
            case 1: return Color.Orange;
            case 2: return Color.Yellow;
            case 3: return Color.Green;
            case 4: return Color.Blue;
            case 5: return Color.BlueViolet;
            case 6: return Color.Violet;
            default: return Color.White;
        }

        // return null;
    }
    private StringAlignment GetSA(int rnd)
    {
        switch (rnd)
        {
            case 0: return StringAlignment.Center;
            case 1: return StringAlignment.Far;
            case 2: return StringAlignment.Near;
            default: return StringAlignment.Center;
        }
    }
    private HatchStyle GetHS(int rnd)
    {
        switch (rnd)
        {
            case 0: return HatchStyle.BackwardDiagonal;
            case 1: return HatchStyle.Cross;
            case 2: return HatchStyle.DarkDownwardDiagonal;
            case 3: return HatchStyle.DarkHorizontal;
            case 4: return HatchStyle.DarkUpwardDiagonal;
            case 5: return HatchStyle.DarkVertical;
            case 6: return HatchStyle.DashedDownwardDiagonal;
            case 7: return HatchStyle.DashedHorizontal;
            case 8: return HatchStyle.DashedUpwardDiagonal;
            case 9: return HatchStyle.DashedVertical;
            case 10: return HatchStyle.DiagonalBrick;
            case 11: return HatchStyle.DiagonalCross;
            case 12: return HatchStyle.Divot;
            case 13: return HatchStyle.DottedDiamond;
            case 14: return HatchStyle.DottedGrid;
            case 15: return HatchStyle.ForwardDiagonal;
            case 16: return HatchStyle.Horizontal;
            case 17: return HatchStyle.HorizontalBrick;
            case 18: return HatchStyle.LargeCheckerBoard;
            case 19: return HatchStyle.LargeConfetti;
            case 20: return HatchStyle.LargeGrid;
            //case 21: return HatchStyle.LightDownwardDiagonal;
            //case 22: return HatchStyle.LightHorizontal;
            //case 23: return HatchStyle.LightUpwardDiagonal;
            //case 24: return HatchStyle.LightVertical;
            //case 25: return HatchStyle.Max;
            //case 26: return HatchStyle.Min;
            case 27: return HatchStyle.NarrowHorizontal;
            case 28: return HatchStyle.NarrowVertical;
            case 29: return HatchStyle.OutlinedDiamond;
            case 30: return HatchStyle.Plaid;
            case 31: return HatchStyle.Shingle;
            case 32: return HatchStyle.SmallCheckerBoard;
            case 33: return HatchStyle.SmallConfetti;
            case 34: return HatchStyle.SmallGrid;
            case 35: return HatchStyle.SolidDiamond;
            case 36: return HatchStyle.Sphere;
            case 37: return HatchStyle.Trellis;
            case 38: return HatchStyle.Vertical;
            case 39: return HatchStyle.Wave;
            case 40: return HatchStyle.Weave;
            case 41: return HatchStyle.WideDownwardDiagonal;
            case 42: return HatchStyle.WideUpwardDiagonal;
            case 43: return HatchStyle.ZigZag;
            default: return HatchStyle.Plaid;
        }
        //            return hs;
    }
    private bool isDifferentColor(Color c1, Color c2, int delta)
    {
        int red1 = Convert.ToInt32(c1.R);
        int green1 = Convert.ToInt32(c1.G);
        int blue1 = Convert.ToInt32(c1.B);

        int red2 = Convert.ToInt32(c2.R);
        int green2 = Convert.ToInt32(c2.G);
        int blue2 = Convert.ToInt32(c2.B);

        if (red1 >= red2 - delta && red1 <= red2 + delta)
        {
            return false;
        }
        if (green1 >= green2 - delta && green1 <= green2 + delta)
        {
            return false;
        }
        if (blue1 >= blue2 - delta && blue1 <= blue2 + delta)
        {
            return false;
        }
        return true;
    }
    private Color GetDifferentColor(Color c, int delta, Random random)
    {
        int red1 = Convert.ToInt32(c.R);
        int green1 = Convert.ToInt32(c.G);
        int blue1 = Convert.ToInt32(c.B);

        int red2 = random.Next(255), green2 = random.Next(255), blue2 = random.Next(255);

        while (red1 >= red2 - delta && red1 <= red2 + delta)
        {
            red2 = random.Next(0, 255);
        }
        while (green1 >= green2 - delta && green1 <= green2 + delta)
        {
            green2 = random.Next(0, 255);
        }
        while (blue1 >= blue2 - delta && blue1 <= blue2 + delta)
        {
            blue2 = random.Next(0, 255);
        }
        //    Color clr = new Color.FromArgb(red2, green2, blue2);
        return Color.FromArgb(red2, green2, blue2);
    }
    private void GenerateImage()
    {

        int contrast = 30;
        Bitmap bitmap = new Bitmap(this.width, this.height, PixelFormat.Format32bppArgb);

        Graphics g = Graphics.FromImage(bitmap);
        Rectangle rect = new Rectangle(0, 0, this.width, this.height);

        Random random = new Random();

        int rnd = random.Next(43);
        //            rnd = 1;
        HatchStyle hs = GetHS(rnd);

        rnd = random.Next(7);
        Color clr = new Color();
        clr = GetColor(rnd);

      /*  Color clr2 = new Color();
      do
        {
            clr2 = GetColor(random.Next(7));
        }
        while (clr2 == clr);
        */Color clr2 = GetDifferentColor(clr,contrast,random);

        HatchBrush b = new HatchBrush(hs, clr, clr2);
        g.FillRectangle(b, rect);

        int emSize = (int)(this.width * 2 / text.Length);
        FontFamily family = fonts[random.Next(fonts.Length - 1)];
        Font font = new Font(family, emSize);
        // Регулировка кегля шрифта до тех пор, пока текст не подойдет к изображению
        SizeF measured = new SizeF(0, 0);
        SizeF workingSize = new SizeF(this.width, this.height);

        while (emSize > 2 &&
            (measured = g.MeasureString(text, font)).Width > workingSize.Width ||
            measured.Height > workingSize.Height)
        {
            font.Dispose();
            font = new Font(family, emSize -= 2);
        }

        StringFormat format = new StringFormat();
        StringAlignment sa = GetSA(random.Next(3));
                    rnd = random.Next(3);
        format.Alignment = GetSA(random.Next(3));
        format.LineAlignment = GetSA(random.Next(3));

        GraphicsPath path = new GraphicsPath();
        path.AddString(this.text, font.FontFamily, (int)font.Style, font.Size, rect, format);

        Color clr3 = new Color(); clr3 = Color.White;
        /*
        do{
            clr3 = GetColor(random.Next(7));
        }
        while (!isDifferentColor(clr,clr3,contrast));*/

        SolidBrush sBrush = new SolidBrush(clr3);

        Pen pen1 = new Pen(sBrush);
        for (int i = 0; i < 10; i ++)
            g.DrawLine(pen1, random.Next(width), random.Next(height),random.Next(width), random.Next(height));
        g.FillPath(sBrush, path);

        font.Dispose();
        sBrush.Dispose();
        g.Dispose();

        this.image = bitmap;
    }
}