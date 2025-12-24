using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sol_denka_stockmanagement.Commons
{
    internal static class Messages
    {
        // Common
        public const string DbSaveFailed = "DBへの登録に失敗しました。重複や入力内容を確認してください。";
        public const string UnexpectedError = "予期しないエラーが発生しました。";
        public const string DbUpdateSuccess = "更新に成功しました。";
        public const string ConfirmTitle = "確認";
        public const string DiscardAndBackConfirm = "入力内容を破棄して前の画面に戻ります。よろしいですか？";
        public const string DiscardAndExitEditMode = "入力内容を破棄して編集モードを終了します。よろしいですか？";
        public const string InitializeDbError = "DB初期化に失敗しました。権限やパスを確認してください。";

        // Location
        public const string LocationNameRequired = "保管場所名を入力してください。";
        public const string LocationRegistered = "保管場所を登録しました。";
        public const string LocationNotFound = "保管場所データが見つかりません";

        // Item
        public const string ItemNameRequired = "アイテム名を入力してください。";
        public const string ItemNotFound = "品目データが見つかりません";
        public const string ItemCategoryRequired = "区分を選択してください。";

    }
}
