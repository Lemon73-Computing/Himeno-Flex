namespace Himeno_Flex;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		//ベンチマーク前にデータを削除(初期化)
		mflops1.Text = "";
		mflops2.Text = "";
		time.Text = "";
        loop.Text = "";
		gosa.Text = "";
        cpu.Text = "";
        pentium.Text = "";

        //ベンチマーク開始

        /*
        [DllImport("himenoBMTxps.dll")]
        static extern int main();
        static extern float jacobi(int nn);
        static extern double fflop(int mx, int my, int mz);
        static extern double mflops(int nn, double cpu, double flop);
        static double second();
        */

        //終了
        mflops1.Text = "test";
        mflops2.Text = "test";
        time.Text = "test";
        loop.Text = "test";
        gosa.Text = "test";
        cpu.Text = "test";
        pentium.Text = "test";

    }
}
