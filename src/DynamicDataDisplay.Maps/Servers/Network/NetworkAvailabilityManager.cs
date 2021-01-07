﻿namespace Microsoft.Research.DynamicDataDisplay.Maps.Servers.Network
{
	using System;
	using System.Net.NetworkInformation;
	using System.Windows;

	public sealed class NetworkAvailabilityManager : WeakEventManager
	{
		private NetworkAvailabilityManager()
		{
			NetworkChange.NetworkAvailabilityChanged += NetworkChange_NetworkAvailabilityChanged;
		}

		public static void AddListener(IWeakEventListener listener)
		{
			CurrentManager.ProtectedAddListener(typeof(NetworkChange), listener);
		}

		public static void RemoveListener(IWeakEventListener listener)
		{
			CurrentManager.ProtectedRemoveListener(typeof(NetworkChange), listener);
		}

		protected override void StartListening(object source)
		{
		}

		void NetworkChange_NetworkAvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
		{
			DeliverEvent(sender, e);
		}

		protected override void StopListening(object source)
		{
		}

		private static NetworkAvailabilityManager CurrentManager
		{
			get
			{
				Type managerType = typeof(NetworkAvailabilityManager);
				NetworkAvailabilityManager currentManager = null;
				try
				{
					currentManager = (NetworkAvailabilityManager)GetCurrentManager(managerType);
				}
				catch (InvalidOperationException)
				{
					// nothing to do
				}

				if (currentManager == null)
				{
					currentManager = new NetworkAvailabilityManager();
					SetCurrentManager(managerType, currentManager);
				}

				return currentManager;
			}
		}
	}
}
