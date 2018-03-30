using System;
using Logger.Interfaces;
using Logger.Layouts;

namespace Logger.Factory
{
    public class LayoutFactory
    {
        public ILayout CreateLayout(string layoutType)
        {
            ILayout layout = null;

            switch (layoutType)
            {
                case "SimpleLayout":
                    layout = new SimpleLayout();
                    break;

                case "XmlLayout":
                    layout = new XmlLayout();
                    break;

                default:    
                    throw new ArgumentException("Invalid Layout Type!");
            }

            return layout;
        }
    }
}
