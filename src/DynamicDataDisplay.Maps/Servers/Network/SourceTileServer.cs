namespace Microsoft.Research.DynamicDataDisplay.Maps.Servers.Network
{
	using System;
	using Microsoft.Research.DynamicDataDisplay.Charts.Maps;

	public abstract class SourceTileServer : TileServerBase, IDisposable
	{
		private bool xCycling;
		/// <summary>
		/// Gets or sets a value indicating whether use X cycling.
		/// By default is <c>false</c>.
		/// </summary>
		/// <value><c>true</c> if X is cycled; otherwise, <c>false</c>.</value>
		public bool XCycling {
			get => xCycling;
			protected set => xCycling = value;
		}

		private int maxConcurrentDownloads = Int32.MaxValue;
		public int MaxConcurrentDownloads
		{
			get => maxConcurrentDownloads;
			protected set => maxConcurrentDownloads = value;
		}

		private int minLevel = 1;
		public int MinLevel
		{
			get => minLevel;
			protected set => minLevel = value;
		}

		private int maxLevel = 17;
		public int MaxLevel
		{
			get => maxLevel;
			protected set => maxLevel = value;
		}

		private int serversNum;
		public int ServersNum
		{
			get => serversNum;
			protected set => serversNum = value;
		}

		private int minServer;
		public int MinServer
		{
			get => minServer;
			protected set
			{
				minServer = value;
				currentServer = value;
			}
		}

		private string fileExtension = ".png";
		public string FileExtension
		{
			get => fileExtension;
			protected set => fileExtension = value;
		}

		private int currentServer;
		protected int CurrentServer
		{
			get => currentServer;
			set => currentServer = value;
		}

		private string userAgent = "Dynamic Data Display";
		public string UserAgent
		{
			get => userAgent;
			set => userAgent = value;
		}

		private string referer;
		public string Referer
		{
			get => referer;
			set => referer = value;
		}

		private string uriFormat;
		public string UriFormat
		{
			get => uriFormat;
			protected set => uriFormat = value;
		}

		private double maxLatitude = 85;
		public double MaxLatitude
		{
			get => maxLatitude;
			protected set => maxLatitude = value;
		}

		public virtual bool CanLoadFast(TileIndex id)
		{
			return false;
		}

		private int tileWidth = 256;
		public int TileWidth
		{
			get => tileWidth;
			protected set => tileWidth = value;
		}

		private int tileHeight = 256;
		public int TileHeight
		{
			get => tileHeight;
			protected set => tileHeight = value;
		}

		public override bool Equals(object obj)
		{
			if (obj == null) return false;

			return obj.GetType() == GetType();
		}


        public override int GetHashCode()
        {
            return GetType().GetHashCode();
        }

        private bool deleteFileCacheOnUpdate;
        public bool DeleteFileCacheOnUpdate
        {
            get => deleteFileCacheOnUpdate;
            protected set => deleteFileCacheOnUpdate = value;
        }

        public virtual void CancelRunningOperations() { }

		#region IDisposable Members

		public virtual void Dispose()
		{
		}

		#endregion
	}
}
