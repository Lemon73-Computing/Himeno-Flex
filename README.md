# Himeno_Flex

## 概要
こちらのソフトウェアは、[理化学研究所](https://www.riken.jp)/[情報システム部](https://i.riken.jp)
より発表されている[姫野ベンチマーク](https://i.riken.jp/supercom/documents/himenobmt/)をGUIにしたソフトウェアです。<br />
併せて[解説ページ](https://lemon73.gitlab.io/apps/himeno)もご覧ください。

## 開発状況
進捗: **開発停止**

- **完成部分**
  - 姫野ベンチマーク読み込み部分(Windowsのみ)
  - アイコン/起動画面
  - UI

- **未完成部分**
  - 姫野ベンチマーク読み込み部分(Windows以外)

## 技術
- フレームワーク
  - .NET 7.0
  - MAUI

- プログラム言語
  - C#(メイン)
  - C++/CLI(C言語で書かれた姫野ベンチマークを一部書き換えています)

- デザイン言語
  - .xaml

## ライセンス
- [LGPLv2.1](LICENSE.txt)

## 従来の姫野ベンチマークとの比較
- UI<br />
従来品: CUIで、特に非プログラマー勢にとってはとっつきにくいものでした。<br />
こちら: GUIで、誰でも使いやすく、見た目も見やすいものを目指しました。<br />

- ダウンロード手順<br />
従来品: <br />
.zipファイル→展開→.lzhファイル→展開→.cファイル→ビルド(makeコマンド)→./bmt(起動)<br />
のようにダウンロードしてから実際に動かすまでかなり手間がかかっていました。<br />
こちら: ダウンロードしたらすぐに使えるようになっています。<br />

- 対応OS<br />
従来品: 公式ではWindows/MacOS向けと、C言語のLinuxやUnixなどで使えるコードが配布されています。<br />
こちら: こちらでは、Windows ~~/MacOS/Android/iOS~~ に対応しています。(Linux/Unixでは動作しません。)<br />
(※当初の予定ではWindows/MacOS/Android/iOSに対応予定でしたが、Androidは技術不足で開発困難、MacOS/iOSは実機テストが不可能なために開発を断念しました。)
<details>
  <summary>Android版撤退の経緯</summary>
  初めに、こちらのソフトウェアの仕組みですが、GUI部分(Himeno_Flex)から姫野ベンチマーク(HimenoBMTxps)を読み込んでいます。<br />
  読み込む方法として、Windows版では、.dllを利用しており、Android版でも同様に.dllでの読み込みを想定していましたが、<br />
  次のような問題が発生しました。<br />
  ・.dllはAndroidで読み込めない?<br />
  インターネットの情報では、読み込める説と読み込めない説が混在しており、真偽は不明です。<br />
  ・どのようにしてファイルに入れる?<br />
  .dllまたは、Android用の代替案の.soファイルをビルドした際にAndroidファイルの中に入れなければなりませんが、<br />
  どのファイルに入れればよいかの情報が全く見つかりませんでした。<br />
  Xamarin時代はAssetファイルに入れていたようですが、MAUIではそのようなファイルは存在しないので、どのファイルに入れればよいのかがわかりません。<br />
  Resoruce/Raw説がありますが…<br />
  .csprojでdll importするなども試していますが、それも特に意味はなさそうです。<br />
  <br />
  といったように、姫野ベンチマーク(HimenoBMTxps)部分の読み込みに苦労したうえ、進展がないと見込みましたので、開発停止とさせていただきます。<br />
  これについて詳しい方はぜひご意見いただけると幸いです。<br />
</details>

- コード<br />
従来のコードとほとんど違いはありませんが、時間計測方法など一部変更している点も存在します。<br />

#### もし作り直すなら
以下の構成にするのが適切かもしれません。
- フレームワーク/言語<br />
今回: .NET MAUI/C#
再作成: Qt/C++

- HimenoBMTxpsの言語<br />
今回: C++/CLI
再作成: C(または本家C++)

(C言語で書かれたものを本家C++やC++/CLIにしたらベンチマーク速度の比較はできないのではないかとも今更思いましたが、そこら辺はどうなのでしょうか…)

**参考になりそうなリンク**<br />
- https://learn.microsoft.com/en-us/xamarin/cross-platform/cpp/<br />
Xamarin時代のC++の使い方。ただし、Xamarin時代とMAUIではディレクトリの構成が異なっており、あまり参考にならなかった気がします…

## 開発する
#### Windows/MacOSの場合
VisualStudioで.slnファイルを開けば利用できるかと思います。<br />

#### Linuxの場合
Android向けのビルドのみ可能だそうです。<br />
ツールはVS Codeを推奨します。(MicrosoftのMAUI拡張機能を追加してご利用ください。)

#### Linux/Solaris向けについて
当初の予定では、Linux/Solaris用としてJavaFX版Himeno_Flexを開発する予定でした。<br />
しかし、こちら(MAUI版)の開発に予想以上の時間がかかったので、JavaFX版を作る予定はありません。<br />
