﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace Nest
{
	public partial interface IElasticClient
	{
		/// <summary>
		/// Acknowledges a watch, to manually throttle execution of the watch's actions
		/// while the watch condition remains <c>true</c>.
		/// An acknowledged watch action remains in the acknowledged (acked) state until the watch’s condition
		/// evaluates to <c>false</c>.
		/// </summary>
		IAcknowledgeWatchResponse AcknowledgeWatch(Id id, Func<AcknowledgeWatchDescriptor, IAcknowledgeWatchRequest> selector = null);

		/// <inheritdoc />
		IAcknowledgeWatchResponse AcknowledgeWatch(IAcknowledgeWatchRequest request);

		/// <inheritdoc />
		Task<IAcknowledgeWatchResponse> AcknowledgeWatchAsync(Id id, Func<AcknowledgeWatchDescriptor, IAcknowledgeWatchRequest> selector = null,
			CancellationToken cancellationToken = default
		);

		/// <inheritdoc />
		Task<IAcknowledgeWatchResponse> AcknowledgeWatchAsync(IAcknowledgeWatchRequest request,
			CancellationToken ct = default
		);
	}

	public partial class ElasticClient
	{
		/// <inheritdoc />
		public IAcknowledgeWatchResponse AcknowledgeWatch(Id id, Func<AcknowledgeWatchDescriptor, IAcknowledgeWatchRequest> selector = null) =>
			AcknowledgeWatch(selector.InvokeOrDefault(new AcknowledgeWatchDescriptor(id)));

		/// <inheritdoc />
		public IAcknowledgeWatchResponse AcknowledgeWatch(IAcknowledgeWatchRequest request) =>
			Dispatch2<IAcknowledgeWatchRequest, AcknowledgeWatchResponse>(request, request.RequestParameters);

		/// <inheritdoc />
		public Task<IAcknowledgeWatchResponse> AcknowledgeWatchAsync(
			Id id,
			Func<AcknowledgeWatchDescriptor, IAcknowledgeWatchRequest> selector = null,
			CancellationToken cancellationToken = default
		) =>
			AcknowledgeWatchAsync(selector.InvokeOrDefault(new AcknowledgeWatchDescriptor(id)), cancellationToken);

		/// <inheritdoc />
		public Task<IAcknowledgeWatchResponse> AcknowledgeWatchAsync(IAcknowledgeWatchRequest request, CancellationToken ct = default) =>
			Dispatch2Async<IAcknowledgeWatchRequest, IAcknowledgeWatchResponse, AcknowledgeWatchResponse>
				(request, request.RequestParameters, ct);
	}
}
