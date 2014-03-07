using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;

namespace Infragistics.Controls.Charts
{
    /// <summary>
    /// Represents a XamDataChart Moving Average Convergence/Divergence (MACD) indicator series.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Default required members: High, Low, Close
    /// </para>
    /// </remarks>
    public class MovingAverageConvergenceDivergenceIndicator : StrategyBasedIndicator
    {
        /// <summary>
        /// Returns the calculation strategy to use for this indicator.
        /// </summary>
        protected override IndicatorCalculationStrategy CalculationStrategy
        {
            get
            {
                return new CalculationStrategies.MovingAverageConvergenceDivergenceIndicatorStrategy();
            }
        }

        /// <summary>
        /// Returns the default style key that should be used for this indicator.
        /// </summary>
        protected override Type StyleKeyType
        {
            get
            {
                return typeof(MovingAverageConvergenceDivergenceIndicator);
            }
        }

        #region ShortPeriod Dependency Property
        /// <summary>
        /// Gets or sets the short moving average period for the current MovingAverageConvergenceDivergenceIndicator object.
        /// <para>
        /// This is a dependency property.
        /// </para>
        /// <remarks>
        /// The typical, and initial, value for short MACD periods is 10.
        /// </remarks>
        /// </summary>
        public int ShortPeriod
        {
            get
            {
                return (int)GetValue(ShortPeriodProperty);
            }
            set
            {
                SetValue(ShortPeriodProperty, value);
            }
        }

        /// <summary>
        /// Identifies the ShortPeriod dependency property.
        /// </summary>
        public static readonly DependencyProperty ShortPeriodProperty =
            CreateShortPeriodProperty(10, typeof(MovingAverageConvergenceDivergenceIndicator));

        /// <summary>
        /// Specifies the short period value to be used for the calculation.
        /// </summary>
        /// <returns>The period to use.</returns>
        protected override int ShortPeriodOverride()
        {
            return ShortPeriod;
        }
        #endregion

        #region LongPeriod Dependency Property
        /// <summary>
        /// Gets or sets the long moving average period for the current MovingAverageConvergenceDivergenceIndicator object.
        /// <para>
        /// This is a dependency property.
        /// </para>
        /// <remarks>
        /// The typical, and initial, value for long MACD periods is 30.
        /// </remarks>
        /// </summary>
        public int LongPeriod
        {
            get
            {
                return (int)GetValue(LongPeriodProperty);
            }
            set
            {
                SetValue(LongPeriodProperty, value);
            }
        }

        /// <summary>
        /// Identifies the LongPeriod dependency property.
        /// </summary>
        public static readonly DependencyProperty LongPeriodProperty =
            CreateLongPeriodProperty(30, typeof(MovingAverageConvergenceDivergenceIndicator));

        /// <summary>
        /// Specifies the long period value to be used for the calculation.
        /// </summary>
        /// <returns>The period to use.</returns>
        protected override int LongPeriodOverride()
        {
            return LongPeriod;
        }
        #endregion

        #region SignalPeriod Dependency Property
        /// <summary>
        /// Gets or sets the long moving average period for the current MovingAverageConvergenceDivergenceIndicator object.
        /// <para>
        /// This is a dependency property.
        /// </para>
        /// <remarks>
        /// The typical, and initial, value for long PVO periods is 30.
        /// </remarks>
        /// </summary>
        public int SignalPeriod
        {
            get
            {
                return (int)GetValue(SignalPeriodProperty);
            }
            set
            {
                SetValue(SignalPeriodProperty, value);
            }
        }

        internal const string SignalPeriodPropertyName = "SignalPeriod";

        /// <summary>
        /// Identifies the SignalPeriod dependency property.
        /// </summary>
        public static readonly DependencyProperty SignalPeriodProperty =
            CreatePeriodPropertyHelper(9,
            typeof(MovingAverageConvergenceDivergenceIndicator),
            SignalPeriodPropertyName);

        /// <summary>
        /// Specifies the trend period to use for the trend line, overriding 
        /// the TrendLinePeriod for the series.
        /// </summary>
        /// <returns>The period to use.</returns>
        protected override int TrendPeriodOverride()
        {
            if (ReadLocalValue(SignalPeriodProperty) == DependencyProperty.UnsetValue)
            {
                return -1;
            }
            return SignalPeriod;
        }
        #endregion

    }

}

namespace Infragistics.Controls.Charts.CalculationStrategies
{
    /// <summary>
    /// Represents the strategy for calculating a MovingAverageConvergenceDivergenceIndicator series.
    /// </summary>
    /// <remarks>
    /// For definition of indicator see: <see cref="MovingAverageConvergenceDivergenceIndicator"/>
    /// </remarks>    
    public class MovingAverageConvergenceDivergenceIndicatorStrategy : IndicatorCalculationStrategy
    {
        /// <summary>
        /// Exposes which columns this strategy uses in its calculation so that the
        /// consumers will know when they should ask the strategy to recalculate.
        /// </summary>
        /// <param name="dataSource">The data source to be used in the calculation</param>
        /// <param name="supportingCalculations">The other calculations that this indicator may depend on.</param>
        /// <returns>The list of column names that this strategy depends on.</returns>
        public override IList<string> BasedOn(FinancialCalculationDataSource dataSource,
            FinancialCalculationSupportingCalculations supportingCalculations)
        {
            List<string> list = new List<string>();
            list.AddRange(dataSource.TypicalColumn.BasedOn);
            list.AddRange(supportingCalculations.EMA.BasedOn);

            return list;
        }
        
        /// <summary>
        /// Performs the calculation for the indicator.
        /// </summary>
        /// <param name="dataSource">The data provided to perform the calculation.</param>
        /// <param name="supportingCalculations">The supporting calculation strategies provided to perform the calculation.</param>
        /// <returns>True if the calculation could be completed.</returns>
        public override bool CalculateIndicator(FinancialCalculationDataSource dataSource,
            FinancialCalculationSupportingCalculations supportingCalculations)
        {
            IEnumerable<double> typicalColumn = dataSource.TypicalColumn;
            IList<double> indicatorColumn = dataSource.IndicatorColumn;
            int shortPeriod = dataSource.ShortPeriod;
            int longPeriod = dataSource.LongPeriod;

            IEnumerator<double> shortEma =
                supportingCalculations.EMA.Strategy(typicalColumn, shortPeriod).GetEnumerator();
            IEnumerator<double> longEma =
                supportingCalculations.EMA.Strategy(typicalColumn, longPeriod).GetEnumerator();

            int i = 0;

            while (shortEma.MoveNext() && longEma.MoveNext())
            {
                double macd = supportingCalculations.MakeSafe(shortEma.Current - longEma.Current);

                indicatorColumn[i] = macd;
                i++;
            }

            return true;
        }
    }
}

#region Copyright (c) 2001-2012 Infragistics, Inc. All Rights Reserved
/* ---------------------------------------------------------------------*
*                           Infragistics, Inc.                          *
*              Copyright (c) 2001-2012 All Rights reserved               *
*                                                                       *
*                                                                       *
* This file and its contents are protected by United States and         *
* International copyright laws.  Unauthorized reproduction and/or       *
* distribution of all or any portion of the code contained herein       *
* is strictly prohibited and will result in severe civil and criminal   *
* penalties.  Any violations of this copyright will be prosecuted       *
* to the fullest extent possible under law.                             *
*                                                                       *
* THE SOURCE CODE CONTAINED HEREIN AND IN RELATED FILES IS PROVIDED     *
* TO THE REGISTERED DEVELOPER FOR THE PURPOSES OF EDUCATION AND         *
* TROUBLESHOOTING. UNDER NO CIRCUMSTANCES MAY ANY PORTION OF THE SOURCE *
* CODE BE DISTRIBUTED, DISCLOSED OR OTHERWISE MADE AVAILABLE TO ANY     *
* THIRD PARTY WITHOUT THE EXPRESS WRITTEN CONSENT OF INFRAGISTICS, INC. *
*                                                                       *
* UNDER NO CIRCUMSTANCES MAY THE SOURCE CODE BE USED IN WHOLE OR IN     *
* PART, AS THE BASIS FOR CREATING A PRODUCT THAT PROVIDES THE SAME, OR  *
* SUBSTANTIALLY THE SAME, FUNCTIONALITY AS ANY INFRAGISTICS PRODUCT.    *
*                                                                       *
* THE REGISTERED DEVELOPER ACKNOWLEDGES THAT THIS SOURCE CODE           *
* CONTAINS VALUABLE AND PROPRIETARY TRADE SECRETS OF INFRAGISTICS,      *
* INC.  THE REGISTERED DEVELOPER AGREES TO EXPEND EVERY EFFORT TO       *
* INSURE ITS CONFIDENTIALITY.                                           *
*                                                                       *
* THE END USER LICENSE AGREEMENT (EULA) ACCOMPANYING THE PRODUCT        *
* PERMITS THE REGISTERED DEVELOPER TO REDISTRIBUTE THE PRODUCT IN       *
* EXECUTABLE FORM ONLY IN SUPPORT OF APPLICATIONS WRITTEN USING         *
* THE PRODUCT.  IT DOES NOT PROVIDE ANY RIGHTS REGARDING THE            *
* SOURCE CODE CONTAINED HEREIN.                                         *
*                                                                       *
* THIS COPYRIGHT NOTICE MAY NOT BE REMOVED FROM THIS FILE.              *
* --------------------------------------------------------------------- *
*/
#endregion Copyright (c) 2001-2012 Infragistics, Inc. All Rights Reserved