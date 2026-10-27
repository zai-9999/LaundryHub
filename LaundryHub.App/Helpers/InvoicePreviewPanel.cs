using System.ComponentModel;
using System.Drawing.Drawing2D;
using LaundryHub.Core.Models;
using CustomerModel = LaundryHub.Core.Models.Customer;

namespace LaundryHub.App.Helpers;

public class InvoicePreviewPanel : Panel
{
    private const int DesignW = 440;   // width the invoice is laid out at (same as the print preview)
    private const int DesignH = 480;   // tall enough to hold the whole invoice

    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Order? Order { get; set; }

    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public CustomerModel? Customer { get; set; }

    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IEnumerable<LoadPrice>? Prices { get; set; }

    public InvoicePreviewPanel()
    {
        SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
    }

    public void SetInvoice(Order order, CustomerModel? customer, IEnumerable<LoadPrice>? prices)
    {
        Order = order;
        Customer = customer;
        Prices = prices;
        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        e.Graphics.Clear(Color.White);
        if (Order == null || Width <= 0 || Height <= 0) return;

        // 1. Draw the invoice at its proper size into an off-screen image (2x for sharpness)
        const int k = 2;
        using var bmp = new Bitmap(DesignW * k, DesignH * k);
        using (var g = Graphics.FromImage(bmp))
        {
            g.Clear(Color.White);
            g.ScaleTransform(k, k);
            InvoiceRenderer.Draw(g, new RectangleF(0, 0, DesignW, 0),
                Order, Customer, AppServices.ShopName, Prices);
        }

        // 2. Shrink that image to fit the panel width, top-aligned
        float scale = (float)Width / DesignW;
        e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        e.Graphics.DrawImage(bmp, new RectangleF(0, 0, Width, DesignH * scale));
    }
}
