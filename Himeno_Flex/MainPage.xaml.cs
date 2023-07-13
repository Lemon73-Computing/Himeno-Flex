using System.Text;

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

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        //HTMLで結果を出力(現時点ではWindowsでCドライブ直下に配置。他のOSではエラーになるかも?)
        string outFilePath = $@"c:\{DateTimeOffset.Now:yyyyMMddHHmmss}_result.html";

        using (var writer = new StreamWriter(outFilePath, false))
        {
            writer.WriteLine("<html>");
            writer.WriteLine("<head>");
            writer.WriteLine("<title>Himeno Flex 結果</title>");
            writer.WriteLine("<link rel=\"icon\" href=\"https://lemon73.gitlab.io/favicon.png\">");
            writer.WriteLine("<meta charset=\"utf-8\">");
            writer.WriteLine("<link rel=\"stylesheet\" href=\"https://lemon73.gitlab.io/style.css\">");
            writer.WriteLine("</head>");

            writer.WriteLine("<body>");
            writer.WriteLine("<header><b><p style=\"padding-left: 8%;\"><a href=\"https://i.riken.jp/supercom/documents/himenobmt/\">Himeno Flex</a></p></b></header>");
            writer.WriteLine("<main>");
            writer.WriteLine("<h1>Himeno Flex ベンチマーク結果</h1>");
            writer.WriteLine($@"<p>MFLOPS: {mflops1.Text}</p>");
            writer.WriteLine($@"<p>時間: {time.Text}</p>");
            writer.WriteLine($@"<p>実行ループ回数: {loop.Text}</p>");
            writer.WriteLine($@"<p>MFLOPS: {mflops2.Text}</p>");
            writer.WriteLine($@"<p>CPU: {cpu.Text}</p>");
            writer.WriteLine($@"<p>Pentium3 600MHzと比較: {pentium.Text}</p>");
            writer.WriteLine("<br />");
            writer.WriteLine($@"<p>記録日時: {DateTimeOffset.Now:yyyy/MM/dd/HH:mm:ss}</p>");
            writer.WriteLine("</main>");
            writer.WriteLine("</body>");
            writer.WriteLine("</html>");
            writer.WriteLine("");
        }
    }
}
