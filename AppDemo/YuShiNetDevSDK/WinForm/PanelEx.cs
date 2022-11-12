using System.Drawing;
using System.Windows.Forms;

public class PanelEx : Panel
{
    public Color m_oBorderColor = new Color();
    public int m_nBorderWidth;
    public ButtonBorderStyle m_oBorderLineStyle;
    public PanelEx()
    {
        m_oBorderColor = new Color();
        m_oBorderLineStyle = ButtonBorderStyle.Solid;
        m_nBorderWidth = 1;
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        if (m_oBorderColor != null)
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle,
                m_oBorderColor, m_nBorderWidth, m_oBorderLineStyle,
                m_oBorderColor, m_nBorderWidth, m_oBorderLineStyle,
                m_oBorderColor, m_nBorderWidth, m_oBorderLineStyle,
                m_oBorderColor, m_nBorderWidth, m_oBorderLineStyle);
    }

    public void setBorderColor(Color oBorderColor, int nBorderWidth)
    {
        m_oBorderColor = oBorderColor;
        m_nBorderWidth = nBorderWidth;
    }
}