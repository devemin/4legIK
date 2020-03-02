# 4legIK
4leg robot IK

Unity 上で４脚ロボットの各脚3軸のIKによる計算をしてみました。

動作のようす
https://twitter.com/devemin/status/1234304828123181056

Math.Net を使います。
下記URLを参考にAsset フォルダにdllをコピーしてください。



If you use this, you have to copy DLL (Math.Net) to Asset folder.

https://note.com/narikinnn/n/nc299291ec60e


# ●使い方
シーン mathnetIK.unity を開きます。

オブジェクト
targetBase を動かすと、ボディが動きます。（position, rotation）
targetFL, FR, RL, RR を動かすと、足先が動きます。（position, rotation）

その位置に合わせて脚サーボがIK計算により動きます。

# その他
素人の自分の学習目的ファイルを、バックアップの意味を含めアップロードしています。
エラー処理や範囲外処理など一切しておりません・・・
試してみたい方はどうぞ。



MIT Liscence.


@devemin
https://twitter.com/devemin
