# 4legIK
4leg robot IK

Unity 上で４脚ロボットの各脚3軸のIKによる計算をしてみました。

ボディや足先をグイグイ動かせます。

動作

https://twitter.com/devemin/status/1234304828123181056


# ●使い方

1. Math.Net を使います。

下記URLを参考にAsset フォルダにdllをコピーすれば使えます。

If you use this, you have to copy DLL (Math.Net) to Asset folder.

https://note.com/narikinnn/n/nc299291ec60e

2. シーン mathnetIK.unity を開きます。

3.再生ボタンを押します。

4. オブジェクト　targetBase を動かすと、ボディが動きます。（position, rotation）
オブジェクト　targetFL, FR, RL, RR を動かすと、足先が動きます。（position, rotation）

その位置に合わせて脚サーボがIK計算により動きます。

# その他
素人の自分の学習目的ファイルを、バックアップの意味を含めアップロードしています。
エラー処理や範囲外処理など一切しておりません・・・
試してみたい方はどうぞ。

Unity 2019.1.10f1

MIT Liscence.


@devemin
https://twitter.com/devemin
