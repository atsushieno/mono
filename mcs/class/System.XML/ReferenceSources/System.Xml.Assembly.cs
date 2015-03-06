//------------------------------------------------------------------------------
// <copyright file="System.Xml.Assembly.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <owner current="true" primary="true">[....]</owner>

using System.Runtime.CompilerServices;

// Friend assemblies
#if MOBILE

#if !FEATURE_CORESYSTEM
[assembly: InternalsVisibleTo("System.ServiceModel, PublicKey=0024000004800000940000000602000000240000525341310004000001000100B5FC90E7027F67871E773A8FDE8938C81DD402BA65B9201D60593E96C492651E889CC13F1415EBB53FAC1131AE0BD333C5EE6021672D9718EA31A8AEBD0DA0072F25D87DBA6FC90FFD598ED4DA35E44C398C454307E8E33B8426143DAEC9F596836F97C8F74750E5975C64E2189F45DEF46B2A2B1247ADC3652BF5C308055DA9", AllInternalsVisible = false)]
#endif

// Depends on XsdDuration
[assembly: InternalsVisibleTo ("System.Runtime.Serialization, PublicKey=00240000048000009400000006020000002400005253413100040000010001008D56C76F9E8649383049F383C44BE0EC204181822A6C31CF5EB7EF486944D032188EA1D3920763712CCB12D75FB77E9811149E6148E5D32FBAAB37611C1878DDC19E20EF135D0CB2CFF2BFEC3D115810C3D9069638FE4BE215DBF795861920E5AB6F7DB2E2CEEF136AC23D5DD2BF031700AEC232F6C6B1C785B4305C123B37AB")]


// Depends on XmlXapResolver.RegisterApplicationResourceStreamResolver and IApplicationResourceStreamResolver opened bug DevDiv:326719 to try and eliminate this dependency
[assembly: InternalsVisibleTo("System.Windows, PublicKey=00240000048000009400000006020000002400005253413100040000010001008D56C76F9E8649383049F383C44BE0EC204181822A6C31CF5EB7EF486944D032188EA1D3920763712CCB12D75FB77E9811149E6148E5D32FBAAB37611C1878DDC19E20EF135D0CB2CFF2BFEC3D115810C3D9069638FE4BE215DBF795861920E5AB6F7DB2E2CEEF136AC23D5DD2BF031700AEC232F6C6B1C785B4305C123B37AB", AllInternalsVisible = false)]

// System.Xml.Serialization needs AllInternalsVisible = true because it needs access to internal methods on XmlRootAttribute and the [FriendAccessAllowed] cannot be placed on an Attribute class.
[assembly: InternalsVisibleTo("System.Xml.Serialization, PublicKey=0024000004800000940000000602000000240000525341310004000001000100B5FC90E7027F67871E773A8FDE8938C81DD402BA65B9201D60593E96C492651E889CC13F1415EBB53FAC1131AE0BD333C5EE6021672D9718EA31A8AEBD0DA0072F25D87DBA6FC90FFD598ED4DA35E44C398C454307E8E33B8426143DAEC9F596836F97C8F74750E5975C64E2189F45DEF46B2A2B1247ADC3652BF5C308055DA9", AllInternalsVisible = true)]

#else
[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("System.Data.SqlXml, PublicKey=00000000000000000400000000000000")]
[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("System.Xml.Linq, PublicKey=00000000000000000400000000000000")]
// This is to allow writing unit tests that test the internal functionality contained in this assembly.
[assembly: InternalsVisibleToAttribute("System.ServiceModel.Friend, PublicKey=002400000480000094000000060200000024000052534131000400000100010007d1fa57c4aed9f0a32e84aa0faefd0de9e8fd6aec8f87fb03766c834c99921eb23be79ad9d5dcc1dd9ad236132102900b723cf980957fc4e177108fc607774f29e8320e92ea05ece4e821c0a5efe8f1645c4c0c93c1ab99285d622caa652c1dfad63d745d6f2de5f17e5eaf0fc4963d261c8a12436518206dc093344d5ad293")]
#endif
