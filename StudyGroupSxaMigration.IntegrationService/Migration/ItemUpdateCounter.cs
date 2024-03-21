using System;
using System.Collections.Generic;
using System.Text;

namespace StudyGroupSxaMigration.IntegrationService.Migration
{
    /// <summary>
    /// Used by migration classes to record a tally of how many items have been inserted / updated
    /// </summary>
    public class ItemUpdateCounter
    {
        public void AppendLatestUpdates(ItemUpdateCounter itemUpdateCounter)
        {
            if (itemUpdateCounter.ItemsFoundInSitecore8 > 0)
            {
                this.ItemsFoundInSitecore8 += itemUpdateCounter.ItemsFoundInSitecore8;
                this.ItemsMigrated += itemUpdateCounter.ItemsMigrated;

                this.ItemsSkipped += itemUpdateCounter.ItemsSkipped;
                this.ItemsFailedToInsert += itemUpdateCounter.ItemsFailedToInsert;
            }
            
            if (itemUpdateCounter.ChildItemsFoundInSitecore8 > 0)
            {
                this.ChildItemsFoundInSitecore8 += itemUpdateCounter.ChildItemsFoundInSitecore8;
                this.ChildItemsMigrated += itemUpdateCounter.ChildItemsMigrated;

                this.ChildItemsSkipped += itemUpdateCounter.ChildItemsSkipped;
                this.ChildItemsFailedToInsert += itemUpdateCounter.ChildItemsFailedToInsert;
            }

            // Page content updates (i.e. meta tags etc.)

            if (itemUpdateCounter.PagesUpdated > 0 || itemUpdateCounter.PagesFailedToUpdate > 0 || itemUpdateCounter.PagesSkipped > 0)
            {
                this.PagesNotFoundInSitecore9 += itemUpdateCounter.PagesNotFoundInSitecore9;
                this.PagesUpdated += itemUpdateCounter.PagesUpdated;
                this.PagesFailedToUpdate += itemUpdateCounter.PagesFailedToUpdate;
                this.PagesSkipped += itemUpdateCounter.PagesSkipped;
            }
        }

        public int ItemsFoundInSitecore8 { get; set; } = 0;
        public int ItemsMigrated { get; set; } = 0;
        public int ItemsSkipped { get; set; } = 0;
        public int ItemsFailedToInsert { get; set; } = 0;

        public int ChildItemsFoundInSitecore8 { get; set; } = 0;
        public int ChildItemsMigrated { get; set; } = 0;
        public int ChildItemsSkipped { get; set; } = 0;
        public int ChildItemsFailedToInsert { get; set; } = 0;

        public int PagesSkipped { get; set; } = 0;
        public int PagesUpdated { get; set; } = 0;
        public int PagesNotFoundInSitecore9 { get; set; } = 0;
        public int PagesFailedToUpdate { get; set; } = 0;
    }
}
