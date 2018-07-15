using System.Windows;
using System.Windows.Controls;

namespace WpfCustomControlLibrary
{
    [TemplatePart(Name = "PART_MINIMIZE", Type = typeof(Button))]
    [TemplatePart(Name = "PART_RESTORE", Type = typeof(Button))]
    [TemplatePart(Name = "PART_CLOSE", Type = typeof(Button))]
    public class CustomWindow : Window
    {
        static CustomWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomWindow), new FrameworkPropertyMetadata(typeof(CustomWindow)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            var minimizeButton = GetTemplateChild("PART_MINIMIZE") as Button;
            minimizeButton.Click += (s, e) => WindowState = WindowState.Minimized;

            var restoreButton = GetTemplateChild("PART_RESTORE") as Button;
            restoreButton.Click += (s, e) =>
            {
                if (WindowState == WindowState.Normal)
                    WindowState = WindowState.Maximized;
                else
                    WindowState = WindowState.Normal;
            };

            var closeButton = GetTemplateChild("PART_CLOSE") as Button;
            closeButton.Click += (s, e) => Close();
        }
    }
}
