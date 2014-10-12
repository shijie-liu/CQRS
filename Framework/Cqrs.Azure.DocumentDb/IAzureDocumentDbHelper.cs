﻿#region Copyright
// // -----------------------------------------------------------------------
// // <copyright company="cdmdotnet Limited">
// // 	Copyright cdmdotnet Limited. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------
#endregion

using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace Cqrs.Azure.DocumentDb
{
	public interface IAzureDocumentDbHelper
	{
		Task<Database> CreateOrReadDatabase(DocumentClient client, string databaseName);

		Task<DocumentCollection> CreateOrReadCollection(DocumentClient client, Database database, string collectionName);
	}
}