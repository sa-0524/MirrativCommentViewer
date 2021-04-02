using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Windows.Forms;
using Windows.Media.SpeechSynthesis;

namespace MirrativCommentViewer.Service
{
    /// <summary>
    /// テキスト読み上げサービス
    /// </summary>
    public class TextSpeechService : IDisposable
    {
        /// <summary>
        /// テキストリスト
        /// </summary>
        private List<string> bufferList = new List<string>();

        /// <summary>
        /// シンセサイザ
        /// </summary>
        private SpeechSynthesizer synthesizer;

        /// <summary>
        /// サウンドプレイヤー
        /// </summary>
        private SoundPlayer player;

        /// <summary>
        /// コメント取得処理タイマ
        /// </summary>
        private Timer timer;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TextSpeechService()
        {
            synthesizer = new SpeechSynthesizer();
            player = new SoundPlayer();

            timer = new Timer();
            timer.Tick += SpeechText;
            timer.Interval = Constants.SpeechInterval;
            timer.Start();
        }

        public void Dispose()
        {
            synthesizer.Dispose();
            player.Dispose();
        }

        /// <summary>
        /// キューに追加
        /// </summary>
        /// <param name="textList">テキスト一覧</param>
        public void Enqueue(IEnumerable<string> textList)
        {
            bufferList.AddRange(textList);
        }

        /// <summary>
        /// 読み上げ処理
        /// </summary>
        private async void SpeechText(object sender, EventArgs e)
        {
            var speechList = new List<string>(bufferList);
            bufferList.Clear();

            foreach (var text in speechList)
            {
                using var synthStream = await synthesizer.SynthesizeTextToStreamAsync(text);
                using var stream = synthStream.AsStreamForRead();
                player.Stream = stream;
                player.PlaySync();
            }
        }
    }
}
