# Himeno_Flex

## 概要
こちらのソフトウェアは、[理化学研究所](https://www.riken.jp)/[情報システム部](https://i.riken.jp)
より発表されている[姫野ベンチマーク](https://i.riken.jp/supercom/documents/himenobmt/)をGUIにしたソフトウェアです。<br />
理論上はWindows/MacOS/Android/iOSで使えます。<br />
(現在の予定ではWindowsのみ配布する予定です。<br />
Windows以外のAndroidなどで使いたい場合はこちらのレポジトリから自分でビルドしてください。)<br />

## 開発状況
完成
- 姫野ベンチマーク読み込み部分(Windowsのみ)
- アイコン/起動画面
- UI

未完成
- 姫野ベンチマーク読み込み部分(Windows以外)
現在Android版の動作に向けて誠意開発中です。

## 技術
プログラム言語
- C#(メイン)
- C++/CLI(C言語で書かれた姫野ベンチマークを一部書き換えています)

フレームワーク
- .NET 7.0
- MAUI

デザイン言語
- .xaml

## ライセンス
[LGPLv2.1](LICENSE.txt)です。<br />
(姫野ベンチマークのライセンスの影響によって)<br />

## 従来の姫野ベンチマークとの比較
- UI
従来: CUIで、特に非プログラマー勢にとってはとっつきにくいものでした。<br />
今回: GUIで、誰でも使いやすく、見た目も見やすいものを目指しました。<br />

- ダウンロード手順
従来: <br />
.zipファイル→展開→.lzhファイル→展開→.cファイル→ビルド(makeコマンド)→./bmt(起動)<br />
のようにダウンロードしてから実際に動かすまでかなり手間がかかっていました。<br />
今回: ダウンロードしたらすぐに使えるようにしました。<br />

- 対応OS
従来: 公式ではWindows/MacOS向けと、C言語のLinuxやUnixなどで使えるコードが配布されています。<br />
今回: こちらでは、Windows/MacOS/Android/iOSに対応しています。(Linux/Unixでは動作しません。)<br />

- コード
従来のコードとほとんど違いはありませんが、時間計測方法など一部変更している点も存在します。<br />

## 開発する
#### Windows/MacOSの場合
VisualStudioで.slnファイルを開けば利用できるかと思います。<br />

#### Linuxの場合
Android向けのビルドのみ可能だそうです。<br />
ツールはVS Codeを推奨します。(MicrosoftのMAUI拡張機能を追加してご利用ください。)<br />
<br />
MAUIはLinuxでも使えるという噂がありますが、実際に使えるかはわかりません…<br />
(自分もLinux向けのビルドをいろいろと試してみましたが無理でした。)<br />

#### Linux/Solaris向けについて
当初の予定では、Linux/Solaris用としてJavaFX版Himeno_Flexを開発する予定でした。<br />
しかし、こちら(MAUI版)の開発に予想以上の時間がかかっているため、JavaFX版を作る可能性は低いです。<br />
