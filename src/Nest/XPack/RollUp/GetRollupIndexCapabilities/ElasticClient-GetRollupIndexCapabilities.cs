﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace Nest
{
	public partial interface IElasticClient
	{
		/// <summary>
		/// </summary>
		IGetRollupIndexCapabilitiesResponse GetRollupIndexCapabilities(
			IndexName index,
			Func<GetRollupIndexCapabilitiesDescriptor, IGetRollupIndexCapabilitiesRequest> selector = null
		);

		/// <inheritdoc cref="GetRollupIndexCapabilities(IndexName, System.Func{Nest.GetRollupIndexCapabilitiesDescriptor,Nest.IGetRollupIndexCapabilitiesRequest})" />
		IGetRollupIndexCapabilitiesResponse GetRollupIndexCapabilities(IGetRollupIndexCapabilitiesRequest request);

		/// <inheritdoc cref="GetRollupIndexCapabilities(IndexName, System.Func{Nest.GetRollupIndexCapabilitiesDescriptor,Nest.IGetRollupIndexCapabilitiesRequest})" />
		Task<IGetRollupIndexCapabilitiesResponse> GetRollupIndexCapabilitiesAsync(
			IndexName index,
			Func<GetRollupIndexCapabilitiesDescriptor, IGetRollupIndexCapabilitiesRequest> selector = null,
			CancellationToken cancellationToken = default
		);

		/// <inheritdoc cref="GetRollupIndexCapabilities(IndexName, System.Func{Nest.GetRollupIndexCapabilitiesDescriptor,Nest.IGetRollupIndexCapabilitiesRequest})" />
		Task<IGetRollupIndexCapabilitiesResponse> GetRollupIndexCapabilitiesAsync(IGetRollupIndexCapabilitiesRequest request,
			CancellationToken ct = default
		);
	}

	public partial class ElasticClient
	{
		/// <inheritdoc cref="GetRollupIndexCapabilities(IndexName, System.Func{Nest.GetRollupIndexCapabilitiesDescriptor,Nest.IGetRollupIndexCapabilitiesRequest})" />
		public IGetRollupIndexCapabilitiesResponse GetRollupIndexCapabilities(
			IndexName index,
			Func<GetRollupIndexCapabilitiesDescriptor, IGetRollupIndexCapabilitiesRequest> selector = null
		) =>
			GetRollupIndexCapabilities(selector.InvokeOrDefault(new GetRollupIndexCapabilitiesDescriptor(index)));

		/// <inheritdoc cref="GetRollupIndexCapabilities(IndexName, System.Func{Nest.GetRollupIndexCapabilitiesDescriptor,Nest.IGetRollupIndexCapabilitiesRequest})" />
		public IGetRollupIndexCapabilitiesResponse GetRollupIndexCapabilities(IGetRollupIndexCapabilitiesRequest request) =>
			Dispatch2<IGetRollupIndexCapabilitiesRequest, GetRollupIndexCapabilitiesResponse>(request, request.RequestParameters);

		/// <inheritdoc cref="GetRollupIndexCapabilities(IndexName, System.Func{Nest.GetRollupIndexCapabilitiesDescriptor,Nest.IGetRollupIndexCapabilitiesRequest})" />
		public Task<IGetRollupIndexCapabilitiesResponse> GetRollupIndexCapabilitiesAsync(
			IndexName index,
			Func<GetRollupIndexCapabilitiesDescriptor, IGetRollupIndexCapabilitiesRequest> selector = null,
			CancellationToken cancellationToken = default
		) =>
			GetRollupIndexCapabilitiesAsync(selector.InvokeOrDefault(new GetRollupIndexCapabilitiesDescriptor(index)), cancellationToken);

		/// <inheritdoc cref="GetRollupIndexCapabilities(IndexName, System.Func{Nest.GetRollupIndexCapabilitiesDescriptor,Nest.IGetRollupIndexCapabilitiesRequest})" />
		public Task<IGetRollupIndexCapabilitiesResponse> GetRollupIndexCapabilitiesAsync(
			IGetRollupIndexCapabilitiesRequest request,
			CancellationToken ct = default
		) =>
			Dispatch2Async<IGetRollupIndexCapabilitiesRequest, IGetRollupIndexCapabilitiesResponse, GetRollupIndexCapabilitiesResponse>
				(request, request.RequestParameters, ct);
	}
}
