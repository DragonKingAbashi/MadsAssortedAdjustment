﻿using System;
using HarmonyLib;
using PhoenixPoint.Geoscape.Levels.Factions.Archeology;
using PhoenixPoint.Geoscape.View;
using PhoenixPoint.Geoscape.View.ViewStates;

namespace MadsAssortedAdjustment
{
    [HarmonyPatch(typeof(UIStateVehicleSelected), "OnVehicleSiteExcavated")]
    public static class UIStateVehicleSelected_OnVehicleSiteExcavated_Patch
    {

        public static void Postfix(UIStateVehicleSelected __instance, SiteExcavationState excavation)
        {
            try
            {
                if (excavation.Site != null)
                {
                    Logger.Info($"[UIStateVehicleSelected_OnVehicleSiteExcavated_POSTFIX] Chase excavation site.");

                    GeoscapeViewContext ___Context = (GeoscapeViewContext)AccessTools.Property(typeof(GeoscapeViewState), "Context").GetValue(__instance, null);
                    ___Context.View.ChaseTarget(excavation.Site, false);
                }
            }
            catch (Exception e)
            {
                Logger.Error(e);
            }
        }
    }
}
