﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information. 

using System.Reactive.Disposables;

namespace System.Reactive.Linq
{
    partial class AsyncObservable
    {
        public static IAsyncObservable<T> Throw<T>(Exception error)
        {
            if (error == null)
                throw new ArgumentNullException(nameof(error));

            return Create<T>(async observer =>
            {
                await observer.OnErrorAsync(error).ConfigureAwait(false);
                return AsyncDisposable.Nop;
            });
        }
    }
}