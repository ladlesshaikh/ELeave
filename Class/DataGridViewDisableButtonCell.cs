using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATTNPAY.Class
{

    public class DataGridViewDisableButtonColumn : System.Windows.Forms.DataGridViewButtonColumn
    {
        public DataGridViewDisableButtonColumn()
        {
            this.CellTemplate = new DataGridViewDisableButtonCell();
        }
    }

    class DataGridViewDisableButtonCell : System.Windows.Forms.DataGridViewButtonCell
   // class DataGridViewDisableButtonColumn : System.Windows.Forms.DataGridViewButtonColumn
    {
        private bool enabledValue;
        public bool Enabled
        {
            get
            {
                return enabledValue;
            }
            set
            {
                enabledValue = value;
            }
        }
        // Override the Clone method so that the Enabled property is copied.
        public override object Clone()
        {
            DataGridViewDisableButtonCell cell =
            (DataGridViewDisableButtonCell)base.Clone();
            cell.Enabled = this.Enabled;
            return cell;
        }
        // By default, enable the button cell.
        public DataGridViewDisableButtonCell()
        {
            this.enabledValue = false;
        }
        protected override void Paint(System.Drawing.Graphics graphics,
        System.Drawing.Rectangle clipBounds, System.Drawing.Rectangle cellBounds, int rowIndex,
        System.Windows.Forms.DataGridViewElementStates elementState, object value,
        object formattedValue, string errorText,
        System.Windows.Forms.DataGridViewCellStyle cellStyle,
        System.Windows.Forms.DataGridViewAdvancedBorderStyle advancedBorderStyle,
        System.Windows.Forms.DataGridViewPaintParts paintParts)
        {
            // The button cell is disabled, so paint the border,
            // background, and disabled button for the cell.
            if (!this.enabledValue)
            {
                // Draw the cell background, if specified.
                if ((paintParts & System.Windows.Forms.DataGridViewPaintParts.Background) ==
                System.Windows.Forms.DataGridViewPaintParts.Background)
                {
                    System.Drawing.SolidBrush cellBackground =
                    new System.Drawing.SolidBrush(cellStyle.BackColor);
                    graphics.FillRectangle(cellBackground, cellBounds);
                    cellBackground.Dispose();
                }
                // Draw the cell borders, if specified.
                if ((paintParts & System.Windows.Forms.DataGridViewPaintParts.Border) ==
                System.Windows.Forms.DataGridViewPaintParts.Border)
                {
                    PaintBorder(graphics, clipBounds, cellBounds, cellStyle,
                    advancedBorderStyle);
                }
                // Calculate the area in which to draw the button.
                System.Drawing.Rectangle buttonArea = cellBounds;
                System.Drawing.Rectangle buttonAdjustment =
                this.BorderWidths(advancedBorderStyle);
                buttonArea.X += buttonAdjustment.X;
                buttonArea.Y += buttonAdjustment.Y;
                buttonArea.Height -= buttonAdjustment.Height;
                buttonArea.Width -= buttonAdjustment.Width;
                // Draw the disabled button.
                System.Windows.Forms.ButtonRenderer.DrawButton(graphics, buttonArea,
                System.Windows.Forms.VisualStyles.PushButtonState.Disabled);
                // Draw the disabled button text.
                if (this.FormattedValue is String)
                {
                    System.Windows.Forms.TextRenderer.DrawText(graphics,
                    (string)this.FormattedValue,
                    this.DataGridView.Font,
                    buttonArea, System.Drawing.SystemColors.GrayText);
                }
            }
            else
            {
                // The button cell is enabled, so let the base class
                // handle the painting.
                base.Paint(graphics, clipBounds, cellBounds, rowIndex,
                elementState, value, formattedValue, errorText,
                cellStyle, advancedBorderStyle, paintParts);
            }
        }
    }
}
