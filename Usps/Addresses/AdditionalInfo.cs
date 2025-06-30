namespace SunAuto.Usps.Client.Addresses;

/// <summary>
/// Additional information for addresses.
/// </summary>
public class AdditionalInfo
{
    /// <summary>
    /// A specific set of digits between 00 and 99 is assigned to every address that is combined with the ZIP + 4&#174; Code to provide a unique identifier for every delivery address.
    /// </summary>
    /// <remarks>
    /// A street address does not necessarily represent a single delivery point because a street address such as one for an apartment building may have several delivery points.
    /// </remarks>
    public string? DeliveryPoint { get; set; }

    /// <summary>
    /// This is the carrier route code (values unspecified).
    /// </summary>
    /// <remarks>
    /// Example: C012
    /// </remarks>
    public string? CarrierRoute { get; set; }

    /// <summary>
    /// The DPV Confirmation Indicator is the primary method used by\n  the USPS&#174; to determine whether an address is considered deliverable or\n  undeliverable.\n* Y 'Address was DPV confirmed for both primary and (if present) secondary\n  numbers.'\n* D 'Address was DPV confirmed for the primary number only, and the secondary\n  number information was missing.'\n* S 'Address was DPV confirmed for the primary number only, and the secondary\n  number information was present but not confirmed.'\n* N 'Both primary and (if present) secondary number information failed to\n  DPV confirm.'            
    /// </summary>
    /// <remarks>
    /// Example: enum:
    ///         - "Y"
    ///         - D
    ///         - S
    ///         - "N"
    /// </remarks>
    public string? DPVConfirmation { get; set; }

    /// <summary>
    /// Indicates if the location is a [Commercial Mail Receiving Agency <seealso cref="https://faq.usps.com/s/article/Commercial-Mail-Receiving-Agency-CMRA"/>
    ///      * Y 'Address was found in the CMRA table. '
    ///      * N 'Address was not found in the CMRA table.'
    /// </summary>
    /// <remarks>
    /// Example: enum:
    ///         - "Y"
    ///         - "N"
    /// </remarks>
    public string? DPVCMRA { get; set; }

    /// <summary>
    /// Indicates whether this is a business address. * Y  'The address is a business address.' * N  'The address is not a business address.'
    /// </summary>
    /// <remarks`>
    /// enum:`  
    /// - "Y"
    /// - "N"
    /// </remarks>
    public string? Business { get; set; }

    /// <summary>
    /// Central Delivery is for all business office buildings and/or industrial/professional parks. This may include call\n  windows, horizontal locked mail receptacles, and cluster box units.\n  \n  * Y  'The address is a central delivery point.'\n  \n  * N  'The address is not a central delivery point.'
    /// </summary>
    /// <remarks`>
    /// enum:`  
    /// - "Y"
    /// - "N"
    /// </remarks>
    public string? CentralDeliveryPoint { get; set; }

    /// <summary>
    /// Indicates whether the location designated by the address is\n  occupied.\n  \n* Y  'The address is not occupied.' * N  'The address is occupied.' 
    /// </summary>
    /// <remarks`>
    /// enum:`  
    /// - "Y"
    /// - "N"
    /// </remarks>
    public string? Vacant { get; set; }
}