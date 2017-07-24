
using System;

namespace YMK.FrameWork.EntityBean
{
	public class TblAudioFile  : BaseEntity
	{
		
		//音声ファイル番号
		private string _audioFileNo;
		
		//ファイルパス
		private string _audioFileUrl;
		
		//更新ユーザＩＤ
		private string _updUserId;
		
		//更新日時
		private DateTime _updTime;
		
		
		
		public string AudioFileNo
		{
			get
			{
				return _audioFileNo;
			}
			set
			{
				_audioFileNo = value;
			}
			
		}
		
		public string AudioFileUrl
		{
			get
			{
				return _audioFileUrl;
			}
			set
			{
				_audioFileUrl = value;
			}
			
		}
		
		public string UpdUserId
		{
			get
			{
				return _updUserId;
			}
			set
			{
				_updUserId = value;
			}
			
		}
		
		public DateTime UpdTime
		{
			get
			{
				return _updTime;
			}
			set
			{
				_updTime = value;
			}
			
		}
		
	}
}
