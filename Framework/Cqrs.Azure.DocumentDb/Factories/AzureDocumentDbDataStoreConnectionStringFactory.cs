﻿using System;
using Cqrs.Logging;
using Microsoft.Azure.Documents.Client;
using Microsoft.WindowsAzure;

namespace Cqrs.Azure.DocumentDb.Factories
{
	public class AzureDocumentDbDataStoreConnectionStringFactory : IAzureDocumentDbDataStoreConnectionStringFactory
	{
		protected ILog Logger { get; private set; }

		public AzureDocumentDbDataStoreConnectionStringFactory(ILog logger)
		{
			Logger = logger;
		}

		public virtual DocumentClient GetAzureDocumentDbConnectionClient()
		{
			Logger.LogDebug("Getting Azure document client", "AzureDocumentDbDataStoreConnectionStringFactory\\GetAzureDocumentDbConnectionClient");
			try
			{
				return new DocumentClient(GetAzureDocumentDbConnectionUrl(), GetAzureDocumentDbAuthorisationKey());
			}
			finally
			{
				Logger.LogDebug("Getting Azure document client... Done", "AzureDocumentDbDataStoreConnectionStringFactory\\GetAzureDocumentDbConnectionClient");
			}
		}

		public virtual string GetAzureDocumentDbDatabaseName()
		{
			return CloudConfigurationManager.GetSetting("Cqrs.Azure.DocumentDb.DabaseName") ?? "CqrsStore";
		}

		protected virtual Uri GetAzureDocumentDbConnectionUrl()
		{
			return new Uri(CloudConfigurationManager.GetSetting("Cqrs.Azure.DocumentDb.Url"));
		}

		protected virtual string GetAzureDocumentDbAuthorisationKey()
		{
			return CloudConfigurationManager.GetSetting("Cqrs.Azure.DocumentDb.AuthorisationKey");
		}
	}
}