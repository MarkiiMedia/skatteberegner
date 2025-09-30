using Xunit;

public class BeregningTest
{
    [Fact]
    public void Billig_julegave_uden_andet_beskattes_ikke()
    {
        Beregning beregning = new Beregning();
        double skat = beregning.SkatVedJulegave(900, 0);
        Assert.Equal(0, skat);
    }

    [Fact]
    public void Maks_julegave_uden_andet_beskattes_ikke()
    {
        Beregning beregning = new Beregning();
        double skat = beregning.SkatVedJulegave(1200, 0);
        Assert.Equal(0, skat);
    }

    [Fact]
    public void Billig_julegave_og_billigt_andet_beskattes_ikke()
    {
        Beregning beregning = new Beregning();
        double skat = beregning.SkatVedJulegave(900, 300);
        Assert.Equal(0, skat);
    }

    [Fact]
    public void Overskredet_julegavegraense_og_bagatelgraense_giver_beskatning()
    {
        Beregning beregning = new Beregning();
        double skat = beregning.SkatVedJulegave(910, 300);
        Assert.Equal(10, skat); // 910 + 300 = 1210 → 1210 - 1200 = 10
    }

    [Fact]
    public void Billig_julegave_og_overskredet_bagatelgraense_giver_delvis_beskatning()
    {
        Beregning beregning = new Beregning();
        double skat = beregning.SkatVedJulegave(900, 500);
        Assert.Equal(500, skat); // Julegaven holdes ude, 900 + 500 = 1400 → 1400 - 1200 = 200 → beskattes med 200, men kun fra andre gaver → 500 beskattes
    }

    [Fact]
    public void Dyr_julegave_over_1200_beskattes_fuldt()
    {
        Beregning beregning = new Beregning();
        double skat = beregning.SkatVedJulegave(1300, 0);
        Assert.Equal(100, skat); // 1300 - 1200 = 100 → julegaven er over 1200 og beskattes
    }

    [Fact]
    public void Dyr_julegave_og_andre_gaver_beskattes_fuldt()
    {
        Beregning beregning = new Beregning();
        double skat = beregning.SkatVedJulegave(1000, 300);
        Assert.Equal(100, skat); // 1000 + 300 = 1300 → 1300 - 1200 = 100 → julegaven > 900 → hele overskud beskattes
    }
}
