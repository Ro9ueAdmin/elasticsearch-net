﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace Nest
{
	public partial interface IElasticClient
	{
		/// <summary>
		/// Retrieves information about different cluster, node, and index level settings that use deprecated
		/// features that will be removed or changed in the next major version.
		/// </summary>
		IDeprecationInfoResponse DeprecationInfo(Func<DeprecationInfoDescriptor, IDeprecationInfoRequest> selector = null);

		/// <summary>
		/// Retrieves information about different cluster, node, and index level settings that use deprecated
		/// features that will be removed or changed in the next major version.
		/// </summary>
		IDeprecationInfoResponse DeprecationInfo(IDeprecationInfoRequest request);

		/// <summary>
		/// Retrieves information about different cluster, node, and index level settings that use deprecated
		/// features that will be removed or changed in the next major version.
		/// </summary>
		Task<IDeprecationInfoResponse> DeprecationInfoAsync(Func<DeprecationInfoDescriptor, IDeprecationInfoRequest> selector = null,
			CancellationToken ct = default
		);

		/// <summary>
		/// Retrieves information about different cluster, node, and index level settings that use deprecated
		/// features that will be removed or changed in the next major version.
		/// </summary>
		Task<IDeprecationInfoResponse> DeprecationInfoAsync(IDeprecationInfoRequest request,
			CancellationToken ct = default
		);
	}

	public partial class ElasticClient
	{
		/// <inheritdoc />
		public IDeprecationInfoResponse DeprecationInfo(Func<DeprecationInfoDescriptor, IDeprecationInfoRequest> selector = null) =>
			DeprecationInfo(selector.InvokeOrDefault(new DeprecationInfoDescriptor()));

		/// <inheritdoc />
		public IDeprecationInfoResponse DeprecationInfo(IDeprecationInfoRequest request) =>
			Dispatch2<IDeprecationInfoRequest, DeprecationInfoResponse>(request, request.RequestParameters);

		/// <inheritdoc />
		public Task<IDeprecationInfoResponse> DeprecationInfoAsync(
			Func<DeprecationInfoDescriptor, IDeprecationInfoRequest> selector = null,
			CancellationToken ct = default
		) => DeprecationInfoAsync(selector.InvokeOrDefault(new DeprecationInfoDescriptor()), ct);

		/// <inheritdoc />
		public Task<IDeprecationInfoResponse> DeprecationInfoAsync(IDeprecationInfoRequest request, CancellationToken ct = default) =>
			Dispatch2Async<IDeprecationInfoRequest, IDeprecationInfoResponse, DeprecationInfoResponse>
				(request, request.RequestParameters, ct);
	}
}
