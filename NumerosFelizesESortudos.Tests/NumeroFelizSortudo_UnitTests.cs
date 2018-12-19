using System;
using Xunit;
using NumerosFelizesESortudos.Lib;

namespace NumerosFelizesESortudos.Tests
{
    public class NumeroFelizSortudo_UnitTests
    {
        #region "EhFeliz..."

        [Theory]
        [InlineData(7)]
        [InlineData(28)]
        [InlineData(100)]
        public void EhFeliz_DeveRetornarVerdadeiroParaValores(int value)
        {
            var result = NumeroFelizSortudo.Instance.EhFeliz(value);

            Assert.True(result);
        }

        [Theory]
        [InlineData(21)]
        [InlineData(37)]
        [InlineData(142)]
        public void EhFeliz_DeveRetornarFalsoParaValores(int value)
        {
            var result = NumeroFelizSortudo.Instance.EhFeliz(value);

            Assert.False(result);
        }        
        #endregion

        #region "EhSortudo..."

        [Theory]
        [InlineData(7)]
        [InlineData(21)]
        [InlineData(37)]
        public void EhSortudo_DeveRetornarVerdadeiroParaValores(int value)
        {
            var result = NumeroFelizSortudo.Instance.EhSortudo(value);

            Assert.True(result);
        }

        [Theory]
        [InlineData(28)]
        [InlineData(100)]
        [InlineData(142)]
        public void EhSortudo_DeveRetornarFalseParaValores(int value)
        {
            var result = NumeroFelizSortudo.Instance.EhSortudo(value);

            Assert.False(result);
        }
        #endregion
    }
}
