namespace Zu.ChromeDevTools.Preload
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// TODO(https://crbug.com/1384419): revisit the list of PrefetchStatus and
    /// filter out the ones that aren't necessary to the developers.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PrefetchStatus
    {
        [JsonStringEnumMemberName("PrefetchAllowed")]
        PrefetchAllowed,
        [JsonStringEnumMemberName("PrefetchFailedIneligibleRedirect")]
        PrefetchFailedIneligibleRedirect,
        [JsonStringEnumMemberName("PrefetchFailedInvalidRedirect")]
        PrefetchFailedInvalidRedirect,
        [JsonStringEnumMemberName("PrefetchFailedMIMENotSupported")]
        PrefetchFailedMIMENotSupported,
        [JsonStringEnumMemberName("PrefetchFailedNetError")]
        PrefetchFailedNetError,
        [JsonStringEnumMemberName("PrefetchFailedNon2XX")]
        PrefetchFailedNon2XX,
        [JsonStringEnumMemberName("PrefetchEvictedAfterBrowsingDataRemoved")]
        PrefetchEvictedAfterBrowsingDataRemoved,
        [JsonStringEnumMemberName("PrefetchEvictedAfterCandidateRemoved")]
        PrefetchEvictedAfterCandidateRemoved,
        [JsonStringEnumMemberName("PrefetchEvictedForNewerPrefetch")]
        PrefetchEvictedForNewerPrefetch,
        [JsonStringEnumMemberName("PrefetchHeldback")]
        PrefetchHeldback,
        [JsonStringEnumMemberName("PrefetchIneligibleRetryAfter")]
        PrefetchIneligibleRetryAfter,
        [JsonStringEnumMemberName("PrefetchIsPrivacyDecoy")]
        PrefetchIsPrivacyDecoy,
        [JsonStringEnumMemberName("PrefetchIsStale")]
        PrefetchIsStale,
        [JsonStringEnumMemberName("PrefetchNotEligibleBrowserContextOffTheRecord")]
        PrefetchNotEligibleBrowserContextOffTheRecord,
        [JsonStringEnumMemberName("PrefetchNotEligibleDataSaverEnabled")]
        PrefetchNotEligibleDataSaverEnabled,
        [JsonStringEnumMemberName("PrefetchNotEligibleExistingProxy")]
        PrefetchNotEligibleExistingProxy,
        [JsonStringEnumMemberName("PrefetchNotEligibleHostIsNonUnique")]
        PrefetchNotEligibleHostIsNonUnique,
        [JsonStringEnumMemberName("PrefetchNotEligibleNonDefaultStoragePartition")]
        PrefetchNotEligibleNonDefaultStoragePartition,
        [JsonStringEnumMemberName("PrefetchNotEligibleSameSiteCrossOriginPrefetchRequiredProxy")]
        PrefetchNotEligibleSameSiteCrossOriginPrefetchRequiredProxy,
        [JsonStringEnumMemberName("PrefetchNotEligibleSchemeIsNotHttps")]
        PrefetchNotEligibleSchemeIsNotHttps,
        [JsonStringEnumMemberName("PrefetchNotEligibleUserHasCookies")]
        PrefetchNotEligibleUserHasCookies,
        [JsonStringEnumMemberName("PrefetchNotEligibleUserHasServiceWorker")]
        PrefetchNotEligibleUserHasServiceWorker,
        [JsonStringEnumMemberName("PrefetchNotEligibleUserHasServiceWorkerNoFetchHandler")]
        PrefetchNotEligibleUserHasServiceWorkerNoFetchHandler,
        [JsonStringEnumMemberName("PrefetchNotEligibleRedirectFromServiceWorker")]
        PrefetchNotEligibleRedirectFromServiceWorker,
        [JsonStringEnumMemberName("PrefetchNotEligibleRedirectToServiceWorker")]
        PrefetchNotEligibleRedirectToServiceWorker,
        [JsonStringEnumMemberName("PrefetchNotEligibleBatterySaverEnabled")]
        PrefetchNotEligibleBatterySaverEnabled,
        [JsonStringEnumMemberName("PrefetchNotEligiblePreloadingDisabled")]
        PrefetchNotEligiblePreloadingDisabled,
        [JsonStringEnumMemberName("PrefetchNotFinishedInTime")]
        PrefetchNotFinishedInTime,
        [JsonStringEnumMemberName("PrefetchNotStarted")]
        PrefetchNotStarted,
        [JsonStringEnumMemberName("PrefetchNotUsedCookiesChanged")]
        PrefetchNotUsedCookiesChanged,
        [JsonStringEnumMemberName("PrefetchProxyNotAvailable")]
        PrefetchProxyNotAvailable,
        [JsonStringEnumMemberName("PrefetchResponseUsed")]
        PrefetchResponseUsed,
        [JsonStringEnumMemberName("PrefetchSuccessfulButNotUsed")]
        PrefetchSuccessfulButNotUsed,
        [JsonStringEnumMemberName("PrefetchNotUsedProbeFailed")]
        PrefetchNotUsedProbeFailed,
    }
}