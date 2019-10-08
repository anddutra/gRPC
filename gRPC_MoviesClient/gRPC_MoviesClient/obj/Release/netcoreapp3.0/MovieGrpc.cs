// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/movie.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace gRPC_Movies {
  public static partial class MovieSvc
  {
    static readonly string __ServiceName = "Movie.MovieSvc";

    static readonly grpc::Marshaller<global::gRPC_Movies.MovieRequest> __Marshaller_Movie_MovieRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::gRPC_Movies.MovieRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::gRPC_Movies.MovieReply> __Marshaller_Movie_MovieReply = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::gRPC_Movies.MovieReply.Parser.ParseFrom);

    static readonly grpc::Method<global::gRPC_Movies.MovieRequest, global::gRPC_Movies.MovieReply> __Method_GetMovies = new grpc::Method<global::gRPC_Movies.MovieRequest, global::gRPC_Movies.MovieReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetMovies",
        __Marshaller_Movie_MovieRequest,
        __Marshaller_Movie_MovieReply);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::gRPC_Movies.MovieReflection.Descriptor.Services[0]; }
    }

    /// <summary>Client for MovieSvc</summary>
    public partial class MovieSvcClient : grpc::ClientBase<MovieSvcClient>
    {
      /// <summary>Creates a new client for MovieSvc</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public MovieSvcClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for MovieSvc that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public MovieSvcClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected MovieSvcClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected MovieSvcClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::gRPC_Movies.MovieReply GetMovies(global::gRPC_Movies.MovieRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetMovies(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::gRPC_Movies.MovieReply GetMovies(global::gRPC_Movies.MovieRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetMovies, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::gRPC_Movies.MovieReply> GetMoviesAsync(global::gRPC_Movies.MovieRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetMoviesAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::gRPC_Movies.MovieReply> GetMoviesAsync(global::gRPC_Movies.MovieRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetMovies, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override MovieSvcClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new MovieSvcClient(configuration);
      }
    }

  }
}
#endregion