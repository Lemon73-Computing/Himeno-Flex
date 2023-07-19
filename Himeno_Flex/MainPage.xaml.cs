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

    //姫野ベンチマーク(C言語)読み取り
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

        //dll存在判定(temp)
        string dllPath = "HimenoBMTxps.dll";
        if (File.Exists(dllPath))
        {
        //ベンチマーク開始
            try
            {
                main();//C言語のmain関数を実行する
                mflops1.Text = "clear";
                mflops1.Text = "main_clear";
            }
            catch
            {
                mflops1.Text = "main_error";
            }
        }
        else
        {
            mflops1.Text = "main_no dll";
        }
        {
            main(); //C言語のmain関数を実行する 
        }
        */

        //終了
        //mflops1.Text = "test";
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
}
