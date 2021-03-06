﻿#region Copyright
// // -----------------------------------------------------------------------
// // <copyright company="Chinchilla Software Limited">
// // 	Copyright Chinchilla Software Limited. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------
#endregion

using System;
using System.Collections.Generic;
using Cqrs.Entities;

namespace Cqrs.Mongo.DataStores.Indexes
{
	/// <summary>
	/// An index for MongoDB.
	/// </summary>
	/// <typeparam name="TEntity">The <see cref="Type"/> of <see cref="IEntity"/> this index is for.</typeparam>
	public abstract class MongoIndex<TEntity>
	{
		/// <summary>
		/// Indicates if the index enforces unique values. Defaults to false.
		/// </summary>
		public bool IsUnique { get; protected set; }

		/// <summary>
		/// Indicates if the index is in ascending order or descending. Defaults to true meaning ascending order.
		/// </summary>
		public bool IsAcending { get; protected set; }

		/// <summary>
		/// The name of the index. Default to the class name removing any instances of "Index" and "MongoIndex" from the name.
		/// </summary>
		public string Name { get; protected set; }

		/// <summary>
		/// The selectors that the index is comprised of.
		/// </summary>
		public IEnumerable<System.Linq.Expressions.Expression<Func<TEntity, object>>> Selectors { get; protected set; }

		/// <summary>
		/// Instantiate a new instance of <see cref="MongoIndex{TEntity}"/>.
		/// </summary>
		protected MongoIndex()
		{
			IsUnique = false;
			IsAcending = true;
			Name = GetType()
				.Name
				.Replace("MongoIndex", string.Empty)
				.Replace("Index", string.Empty);
		}
	}
}