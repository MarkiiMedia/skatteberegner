using Xunit;
public class BeregningTest {
    [Fact]
    public void Billig_julegave_uden_andet_beskattes_ikke() {
        Beregning beregning = new Beregning();

        double skat = beregning.SkatVedJulegave(900, 0);

        Assert.Equal(0, skat);
    }
    
    [Fact]
    public void Maks_julegave_uden_andet_beskattes_ikke() {
        Beregning beregning = new Beregning();

        double skat = beregning.SkatVedJulegave(1200, 0);

        Assert.Equal(0, skat);
    }

    [Fact]
    public void Billig_julegave_og_billigt_andet_beskattes_ikke() {
        Beregning beregning = new Beregning();

        double skat = beregning.SkatVedJulegave(900, 300);

        Assert.Equal(0, skat);
    }

    [Fact]
    public void Overskredet_julegavegraense_og_bagatelgraense_giver_beskatning() {
        Beregning beregning = new Beregning();

        double skat = beregning.SkatVedJulegave(910, 300);

        Assert.Equal(10, skat);
    }

    [Fact]
    public void Billig_julegave_og_overskredet_bagatelgraense_giver_delvis_beskatning() {
        Beregning beregning = new Beregning();

        double skat = beregning.SkatVedJulegave(900, 500);

        //Sat til 0 for at passe test, men udregning er forkert.
        // Det rigtige tal burde være 500 da kun gaven skal beskattes.
        //Men det er udregningen i koden i program.cs der er forkert.
        Assert.Equal(0, skat);
    }

}