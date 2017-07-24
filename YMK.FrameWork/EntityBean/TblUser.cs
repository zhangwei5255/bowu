
using System;
namespace YMK.FrameWork.EntityBean
{
	public class TblUser  : BaseEntity
	{
		
		//ユーザＩＤ
		private string _userId;
		
		//権限ＩＤ

		private string _roleId;
		
		//パスワード
		private string _pswd;
		
		//ユーザ名称
		private string _userName;
		
		//カタカタ
		private string _katakana;
		
		//メールアドレス
		private string _email;
		
		//電話番号
		private string _telPhone;
		
		//生年月日
		private DateTime? _birthDay;
		
		//性別
		private string _sex;
		
		//住所
		private string _addresse;
		
		//郵便番号
		private string _postNo;
		
		//登録日時
		private DateTime _regTime;
		
		//更新日時
		private DateTime _lastUpdTime;
		
		
		
		public string UserId
		{
			get
			{
				return _userId;
			}
			set
			{
				_userId = value;
			}
			
		}
		
		public string RoleId
		{
			get
			{
				return _roleId;
			}
			set
			{
				_roleId = value;
			}
			
		}
		
		public string Pswd
		{
			get
			{
				return _pswd;
			}
			set
			{
				_pswd = value;
			}
			
		}
		
		public string UserName
		{
			get
			{
				return _userName;
			}
			set
			{
				_userName = value;
			}
			
		}
		
		public string Katakana
		{
			get
			{
				return _katakana;
			}
			set
			{
				_katakana = value;
			}
			
		}
		
		public string Email
		{
			get
			{
				return _email;
			}
			set
			{
				_email = value;
			}
			
		}
		
		public string TelPhone
		{
			get
			{
				return _telPhone;
			}
			set
			{
				_telPhone = value;
			}
			
		}
		
		public DateTime? BirthDay
		{
			get
			{
				return _birthDay;
			}
			set
			{
				_birthDay = value;
			}
			
		}
		
		public string Sex
		{
			get
			{
				return _sex;
			}
			set
			{
				_sex = value;
			}
			
		}
		
		public string Addresse
		{
			get
			{
				return _addresse;
			}
			set
			{
				_addresse = value;
			}
			
		}
		
		public string PostNo
		{
			get
			{
				return _postNo;
			}
			set
			{
				_postNo = value;
			}
			
		}
		
		public DateTime RegTime
		{
			get
			{
				return _regTime;
			}
			set
			{
				_regTime = value;
			}
			
		}
		
		public DateTime LastUpdTime
		{
			get
			{
				return _lastUpdTime;
			}
			set
			{
				_lastUpdTime = value;
			}
			
		}
		
	}
}
