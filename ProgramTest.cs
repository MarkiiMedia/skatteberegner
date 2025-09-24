using Xunit;
using Transport;

namespace TransportTests
{
    public class TransportBeregnerTests
    {
        [Theory]
        [InlineData(3, 5, 0)] // Under 5km og under 10kg er pris 0kr
        [InlineData(3, 12, 50)] // Under 5km og 10kg eller mere er pris 50kr
        [InlineData(7, 5, 75)] // 5km eller mere og under 10kg er pris 75kr
        [InlineData(7, 12, 100)] // 5km eller mere og 10kg eller over er pris 100kr
                                 //Jeg forstår ikke at rækkefølgen i mine consol logs er 4,1,3,2 i ovenstående tests
                                 // Når jeg kigger i koden, burde den jo starte oppefra og ned.
                                 //  ChatGpt siger at det kan køres i facts. Det har jeg prøvet nedenunder, men virker lidt forvirrende
                                 // Det har jeg udkommenteret nederst. Men også læst at den kører ikke oppefra ned. God læring.

        public void BeregnPris_BeregnerKorrektPris(double afstand, double vaegt, int forventetPris)
        {
            //Arrange
            var beregner = new TransportBeregner();

            //Act
            var resultat = beregner.BeregnPris(afstand, vaegt);

            //Assert
            Assert.Equal(forventetPris, resultat);
        }
    }

    // Anden version ved brug af facts. ChatGPT hjulpet.
    // public class TransportBeregnerTests2
    //     {
    //         [Fact]
    //         public void Test1_Under5km_Under10kg_Gratis()
    //         {
    //             var beregner = new TransportBeregner();
    //             var resultat = beregner.BeregnPris(3, 5);
    //             Assert.Equal(0, resultat);
    //         }

    //         [Fact]
    //         public void Test2_Under5km_Over10kg_50kr()
    //         {
    //             var beregner = new TransportBeregner();
    //             var resultat = beregner.BeregnPris(3, 12);
    //             Assert.Equal(50, resultat);
    //         }

    //         [Fact]
    //         public void Test3_Over5km_Under10kg_75kr()
    //         {
    //             var beregner = new TransportBeregner();
    //             var resultat = beregner.BeregnPris(7, 5);
    //             Assert.Equal(75, resultat);
    //         }

    //         [Fact]
    //         public void Test4_Over5km_Over10kg_100kr()
    //         {
    //             var beregner = new TransportBeregner();
    //             var resultat = beregner.BeregnPris(7, 12);
    //             Assert.Equal(100, resultat);
    //         }
    //     }


}

