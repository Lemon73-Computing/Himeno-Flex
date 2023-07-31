using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Storage;
using Microsoft.Maui.ApplicationModel;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Himeno_Flex;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        if (size.SelectedIndex == -1)
        {
            //未選択時
            ram.Text = "規模が選択されていません。";
        }
        else
        {
            //「規模」欄に反映
            ram.Text = size.SelectedIndex switch
            {
                0 => "SSmall",
                1 => "Small",
                2 => "Middle",
                3 => "Large",
                4 => "ELarge",
                _ => "Size Error",
            };

            //ベンチマーク前にデータを削除(初期化)
            mflops1.Text = "測定中";
            mflops2.Text = "測定中";
            time.Text = "測定中";
            loop.Text = "測定中";
            gosa.Text = "測定中";
            cpu.Text = "測定中";
            pentium.Text = "測定中";

            //ベンチマーク開始
            try
            {
                int MIMAX;
                int MJMAX;
                int MKMAX;

                switch (ram.Text)
                {
                    case "SSmall":
                        MIMAX = 33;
                        MJMAX = 33;
                        MKMAX = 65;
                        break;

                    case "Small":
                        MIMAX = 65;
                        MJMAX = 65;
                        MKMAX = 129;
                        break;

                    case "Middle":
                        MIMAX = 129;
                        MJMAX = 129;
                        MKMAX = 257;
                        break;

                    case "Large":
                        MIMAX = 257;
                        MJMAX = 257;
                        MKMAX = 513;
                        break;

                    case "ELarge":
                        MIMAX = 513;
                        MJMAX = 513;
                        MKMAX = 1025;
                        break;

                    //null対策
                    default:
                        MIMAX = 0;
                        MJMAX = 0;
                        MKMAX = 0;
                        break;
                }

                [DllImport("HimenoBMTxps.dll")]
                static extern int main();
                [DllImport("HimenoBMTxps.dll")]
                static extern float jacobi(int nn);
                [DllImport("HimenoBMTxps.dll")]
                static extern double fflop(int mx, int my, int mz);
                [DllImport("HimenoBMTxps.dll")]
                static extern double mflops(int nn, double cpu, double flop);
                [DllImport("HimenoBMTxps.dll")]
                static extern double second();

                float[,,] p = new float[MIMAX, MJMAX, MKMAX];
                float[,,,] a = new float[4, MIMAX, MJMAX, MKMAX];
                float[,,,] b = new float[3, MIMAX, MJMAX, MKMAX];
                float[,,,] c = new float[3, MIMAX, MJMAX, MKMAX];
                float[,,] bnd = new float[MIMAX, MJMAX, MKMAX];
                float[,,] wrk1 = new float[MIMAX, MJMAX, MKMAX];
                float[,,] wrk2 = new float[MIMAX, MJMAX, MKMAX];

                int imax, jmax, kmax;
                float omega;

                //ボタンクリックを無効化し、main関数が同時に複数回読み取れないようにする
                Bench_Button.IsEnabled = false;
                Bench_Button.Text = "ベンチマーク中";

                await Task.Run(() => main());//C言語のmain関数を実行する(非同期処理)

                Bench_Button.IsEnabled = true;
                Bench_Button.Text = "ベンチマーク開始";
            }
            catch
            {
                ram.Text = "DLL Error";
            }
        }
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await SaveFile(CancellationToken.None);

        // ファイル保存(.html)
        async Task SaveFile(CancellationToken cancellationToken)
        {
            using var writer = new MemoryStream();
            
            writer.Write(Encoding.UTF8.GetBytes("<html>\r\n"));
            writer.Write(Encoding.UTF8.GetBytes("<head>\r\n"));
            writer.Write(Encoding.UTF8.GetBytes("<title>Himeno Flex ベンチマーク結果</title>\r\n"));
            writer.Write(Encoding.UTF8.GetBytes("<link rel=\"icon\" href=\"https://lemon73.gitlab.io/favicon.png\">\r\n"));
            writer.Write(Encoding.UTF8.GetBytes("<meta charset=\"utf-8\">\r\n"));
            writer.Write(Encoding.UTF8.GetBytes("<meta name=\"viewport\" content=\"width=640\">\r\n"));
            writer.Write(Encoding.UTF8.GetBytes("<link rel=\"stylesheet\" href=\"https://lemon73.gitlab.io/style.css\">\r\n"));
            writer.Write(Encoding.UTF8.GetBytes("</head>\r\n"));

            writer.Write(Encoding.UTF8.GetBytes("<body>\r\n"));
            writer.Write(Encoding.UTF8.GetBytes("<header><b><p style=\"padding-left: 8%;\">Himeno Flex</p></b></header>\r\n"));
            writer.Write(Encoding.UTF8.GetBytes("<main>\r\n"));
            writer.Write(Encoding.UTF8.GetBytes("<h1>Himeno Flex ベンチマーク結果</h1>\r\n"));
            writer.Write(Encoding.UTF8.GetBytes($@"<p>規模: {ram.Text}</p>"+"\r\n"));
            writer.Write(Encoding.UTF8.GetBytes($@"<p>MFLOPS(仮): {mflops1.Text}</p>"+"\r\n"));
            writer.Write(Encoding.UTF8.GetBytes($@"<p>MFLOPS(実測): {mflops2.Text}</p>"+"\r\n"));
            writer.Write(Encoding.UTF8.GetBytes($@"<p>時間: {time.Text}</p>"+"\r\n"));
            writer.Write(Encoding.UTF8.GetBytes($@"<p>実行ループ回数: {loop.Text}</p>"+"\r\n"));
            writer.Write(Encoding.UTF8.GetBytes($@"<p>CPU: {cpu.Text}</p>"+"\r\n"));
            writer.Write(Encoding.UTF8.GetBytes($@"<p>Pentium3 600MHzと比較: {pentium.Text}</p>"+"\r\n"));
            writer.Write(Encoding.UTF8.GetBytes("<br />\r\n"));
            writer.Write(Encoding.UTF8.GetBytes("<br />\r\n"));
            writer.Write(Encoding.UTF8.GetBytes($@"<p>記録日時: {DateTimeOffset.Now:yyyy/MM/dd/HH:mm:ss}</p>"+"\r\n"));
            writer.Write(Encoding.UTF8.GetBytes("</main>\r\n"));
            writer.Write(Encoding.UTF8.GetBytes("</body>\r\n"));
            writer.Write(Encoding.UTF8.GetBytes("</html>\r\n"));
            writer.Seek(0, SeekOrigin.Begin);//Androidに出力するときに、保存したファイル内に何も書き込まれない現象の対策

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

    private async void Button_Clicked_2(object sender, EventArgs e)
    {
        await SaveFile(CancellationToken.None);

        // ファイル保存(.txt)
        async Task SaveFile(CancellationToken cancellationToken)
        {
            using var writer = new MemoryStream();

            writer.Write(Encoding.UTF8.GetBytes("Himeno Flex ベンチマーク結果\r\n"));//\r\nは改行コード
            writer.Write(Encoding.UTF8.GetBytes("\r\n"));
            writer.Write(Encoding.UTF8.GetBytes($@"規模: {ram.Text}"+"\r\n"));
            writer.Write(Encoding.UTF8.GetBytes($@"MFLOPS(仮): {mflops1.Text}"+"\r\n"));
            writer.Write(Encoding.UTF8.GetBytes($@"MFLOPS(実測): {mflops2.Text}"+"\r\n"));
            writer.Write(Encoding.UTF8.GetBytes($@"時間: {time.Text}"+"\r\n"));
            writer.Write(Encoding.UTF8.GetBytes($@"実行ループ回数: {loop.Text}"+"\r\n"));
            writer.Write(Encoding.UTF8.GetBytes($@"CPU: {cpu.Text}"+"\r\n"));
            writer.Write(Encoding.UTF8.GetBytes($@"Pentium3 600MHzと比較: {pentium.Text}"+"\r\n"));
            writer.Write(Encoding.UTF8.GetBytes("\r\n"));
            writer.Write(Encoding.UTF8.GetBytes("\r\n"));
            writer.Write(Encoding.UTF8.GetBytes($@"記録日時: {DateTimeOffset.Now:yyyy/MM/dd/HH:mm:ss}"+"\r\n"));
            writer.Seek(0, SeekOrigin.Begin);//Androidに出力するときに、保存したファイル内に何も書き込まれない現象の対策

            var fileSaverResult = await FileSaver.Default.SaveAsync($@"HimemoFlex_{DateTimeOffset.Now:yyyyMMdd_HHmmss}.txt", writer, cancellationToken);
        }
    }

    private void Size_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
