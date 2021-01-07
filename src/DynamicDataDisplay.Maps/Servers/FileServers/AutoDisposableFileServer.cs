﻿namespace Microsoft.Research.DynamicDataDisplay.Charts.Maps
{
	using System;
	using System.IO;

	/// <summary>
	/// Represents a file system tile server with random name which deletes its contents during application shutdown process.
	/// </summary>
	public class AutoDisposableFileServer : AsyncFileSystemServer
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="AutoDisposableFileServer"/> class.
		/// </summary>
		public AutoDisposableFileServer()
		{
			ServerName = Path.GetRandomFileName();

			Dispatcher.ShutdownStarted += Dispatcher_ShutdownStarted;
			AppDomain.CurrentDomain.DomainUnload += CurrentDomain_DomainUnload;
		}

		void CurrentDomain_DomainUnload(object sender, EventArgs e)
		{
			DeleteCache();
		}

		private void Dispatcher_ShutdownStarted(object sender, EventArgs e)
		{
			DeleteCache();
		}

		private void DeleteCache()
		{
			try
			{
				if (Directory.Exists(CachePath))
					Directory.Delete(CachePath, true);
			}
			catch (Exception exc) { }
		}
	}
}
