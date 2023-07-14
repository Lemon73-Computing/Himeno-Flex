﻿using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Storage;
using System.Text;
using System.Threading.Tasks;

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


    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await SaveFile(CancellationToken.None);

        // ファイル保存
        async Task SaveFile(CancellationToken cancellationToken)
        {
            using var writer = new MemoryStream();

            writer.Write(Encoding.UTF8.GetBytes("<html>"));
            writer.Write(Encoding.UTF8.GetBytes("<head>"));
            writer.Write(Encoding.UTF8.GetBytes("<title>Himeno Flex ベンチマーク結果</title>"));
            writer.Write(Encoding.UTF8.GetBytes("<link rel=\"icon\" href=\"https://lemon73.gitlab.io/favicon.png\">"));
            writer.Write(Encoding.UTF8.GetBytes("<meta charset=\"utf-8\">"));
            writer.Write(Encoding.UTF8.GetBytes("<link rel=\"stylesheet\" href=\"https://lemon73.gitlab.io/style.css\">"));
            writer.Write(Encoding.UTF8.GetBytes("</head>"));

            writer.Write(Encoding.UTF8.GetBytes("<body>"));
            writer.Write(Encoding.UTF8.GetBytes("<header><b><p style=\"padding-left: 8%;\">Himeno Flex</p></b></header>"));
            writer.Write(Encoding.UTF8.GetBytes("<main>"));
            writer.Write(Encoding.UTF8.GetBytes("<h1>Himeno Flex ベンチマーク結果</h1>"));
            writer.Write(Encoding.UTF8.GetBytes($@"<p>MFLOPS(仮): {mflops1.Text}</p>"));
            writer.Write(Encoding.UTF8.GetBytes($@"<p>MFLOPS(実測): {mflops2.Text}</p>"));
            writer.Write(Encoding.UTF8.GetBytes($@"<p>時間: {time.Text}</p>"));
            writer.Write(Encoding.UTF8.GetBytes($@"<p>実行ループ回数: {loop.Text}</p>"));
            writer.Write(Encoding.UTF8.GetBytes($@"<p>CPU: {cpu.Text}</p>"));
            writer.Write(Encoding.UTF8.GetBytes($@"<p>Pentium3 600MHzと比較: {pentium.Text}</p>"));
            writer.Write(Encoding.UTF8.GetBytes("<br />"));
            writer.Write(Encoding.UTF8.GetBytes("<br />"));
            writer.Write(Encoding.UTF8.GetBytes($@"<p>記録日時: {DateTimeOffset.Now:yyyy/MM/dd/HH:mm:ss}</p>"));
            writer.Write(Encoding.UTF8.GetBytes("</main>"));
            writer.Write(Encoding.UTF8.GetBytes("</body>"));
            writer.Write(Encoding.UTF8.GetBytes("</html>"));
            writer.Write(Encoding.UTF8.GetBytes(""));

            var fileSaverResult = await FileSaver.Default.SaveAsync($@"HimemoFlex_{DateTimeOffset.Now:yyyyMMdd_HHmmss}.html", writer, cancellationToken);
            /* ファイル保存通知(成功orエラー+原因)
            if (fileSaverResult.IsSuccessful)
            {
                await Toast.Make($"The file was saved successfully to location: {fileSaverResult.FilePath}").Show(cancellationToken);
            }
            else
            {
                await Toast.Make($"The file was not saved successfully with error: {fileSaverResult.Exception.Message}").Show(cancellationToken);
            }
            */
        }
    }
}
