using MirrativCommentViewer.Dto;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MirrativCommentViewer.Dao
{
    /// <summary>
    /// コメント取得クラス
    /// </summary>
    public class CommentDao
    {
        /// <summary>
        /// HTTPクライアント
        /// </summary>
        private HttpClient client;

        /// <summary>
        /// 放送ID
        /// </summary>
        private string liveId;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="client">HTTPクライアント</param>
        /// <param name="liveId">放送ID</param>
        public CommentDao(HttpClient client, string liveId)
        {
            this.client = client;
            this.liveId = liveId;
        }

        /// <summary>
        /// コメントを取得する
        /// </summary>
        /// <returns>コメント一覧</returns>
        public async Task<List<CommentDto>> GetCommentsAsync()
        {
            List<CommentDto> comments = null;
            var response = await client.GetAsync(Constants.APIUrl + liveId);
            if (response.IsSuccessStatusCode)
            {
                var contents = await response.Content.ReadAsStringAsync();
                var json = JsonSerializer.Deserialize<ResultDto>(contents);
                if (json.status.ok == Constants.StatusOK)
                {
                    comments = json.comments;
                }
            }
            return comments;
        }
    }
}
