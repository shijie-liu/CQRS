﻿using System;
using Cqrs.Logging;
using Microsoft.Azure.Documents.Client;
using Microsoft.WindowsAzure;

namespace Cqrs.Azure.DocumentDb.Events
{
	public class AzureDocumentDbEventStoreConnectionHelper : IAzureDocumentDbEventStoreConnectionHelper
	{
		protected ILog Logger { get; private set; }

		public AzureDocumentDbEventStoreConnectionHelper(ILog logger)
		{
			Logger = logger;
		}

		public virtual DocumentClient GetEventStoreConnectionClient()
		{
			Logger.LogDebug("Getting Azure document client", "AzureDocumentDbEventStoreConnectionHelper\\GetEventStoreConnectionClient");
			try
			{
				return new DocumentClient(GetEventStoreConnectionUrl(), GetEventStoreConnectionAuthorisationKey());
			}
			finally
			{
				Logger.LogDebug("Getting Azure document client... Done", "AzureDocumentDbEventStoreConnectionHelper\\GetEventStoreConnectionClient");
			}
		}

		public virtual string GetEventStoreConnectionLogStreamName()
		{
			return CloudConfigurationManager.GetSetting("Cqrs.EventStore.Azure.DocumentDb.LogStreamName") ?? "CqrsEventStore";
		}

		protected virtual Uri GetEventStoreConnectionUrl()
		{
			return new Uri(CloudConfigurationManager.GetSetting("Cqrs.EventStore.Azure.DocumentDb.Url"));
		}

		protected virtual string GetEventStoreConnectionAuthorisationKey()
		{
			return CloudConfigurationManager.GetSetting("Cqrs.EventStore.Azure.DocumentDb.AuthorisationKey");
		}
	}
}