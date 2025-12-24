using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sol_denka_stockmanagement.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<LedgerItem> LedgerItems { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<InventoryResult> InventoryResults { get; set; }
        public DbSet<InventoryResultType> InventoryResultTypes { get; set; }
        public DbSet<InventorySession> InventorySessions { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<TagHistory> TagHistories { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<ItemUnit> ItemUnits { get; set; }
        public DbSet<ItemTypeFieldSetting> ItemTypeFieldSettings { get; set; }
        public DbSet<LedgerItemEvent> LedgerItemEvents { get; set; }
        public DbSet<CsvTaskType> CsvTaskTypes { get; set; }
        public DbSet<CsvHistory> CsvHistories { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<FieldMaster> FieldMasters { get; set; }
        public DbSet<ItemCategory> ItemCatetories { get; set; }
        public DbSet<Winder> Winders { get; set; }
        public DbSet<TagStatusType> TagStatusTypes { get; set; }
        public DbSet<TagEventType> TagEventTypes { get; set; }
        public DbSet<ProcessType> ProcessType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(@"Data Source=C:\DenkaStockManagementDb\app.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FieldMaster>().HasData(
                new FieldMaster {
                    Field_id = 1, Field_code = "WEIGHT", Field_name = "重量",
                    Data_type = "NUMBER", Control_type = "INPUT", Is_active = 1,
                    Created_at = "2025-01-01", Updated_at = "2025-01-01"
                },
                new FieldMaster {
                    Field_id = 2, Field_code = "LENGTH", Field_name = "長さ",
                    Data_type = "NUMBER", Control_type = "INPUT", Is_active = 1,
                    Created_at = "2025-01-01", Updated_at = "2025-01-01"
                },
                new FieldMaster {
                    Field_id = 3, Field_code = "THICKNESS", Field_name = "厚さ",
                    Data_type = "NUMBER", Control_type = "INPUT", Is_active = 1,
                    Created_at = "2025-01-01", Updated_at = "2025-01-01"
                },
                new FieldMaster {
                    Field_id = 4, Field_code = "WIDTH", Field_name = "巾",
                    Data_type = "NUMBER", Control_type = "INPUT", Is_active = 1,
                    Created_at = "2025-01-01", Updated_at = "2025-01-01"
                },
                new FieldMaster {
                    Field_id = 5, Field_code = "QUANTITY", Field_name = "数量",
                    Data_type = "NUMBER", Control_type = "INPUT", Is_active = 1,
                    Created_at = "2025-01-01", Updated_at = "2025-01-01"
                },
                new FieldMaster {
                    Field_id = 6, Field_code = "WINDER", Field_name = "巻取機",
                    Data_type = "TEXT", Control_type = "DROPDOWN", Is_active = 1,
                    Created_at = "2025-01-01", Updated_at = "2025-01-01"
                },
                new FieldMaster {
                    Field_id = 7, Field_code = "OCCURRENCE_REASON", Field_name = "発生理由",
                    Data_type = "TEXT", Control_type = "INPUT", Is_active = 1,
                   Created_at = "2025-01-01", Updated_at = "2025-01-01"
                },
                new FieldMaster {
                    Field_id = 8, Field_code = "LOT_NO", Field_name = "Lot No",
                    Data_type = "TEXT", Control_type = "INPUT", Is_active = 1,
                    Created_at = "2025-01-01", Updated_at = "2025-01-01"
                },
                new FieldMaster {
                    Field_id = 9, Field_code = "OCCURRED_AT", Field_name = "発生日時",
                    Data_type = "DATETIME", Control_type = "DATETIME_PICKER", Is_active = 1,
                    Created_at = "2025-01-01", Updated_at = "2025-01-01"
                },
                new FieldMaster {
                    Field_id = 10, Field_code = "PROCESSED_AT", Field_name = "処理日時",
                    Data_type = "DATETIME", Control_type = "DATETIME_PICKER", Is_active = 1,
                    Created_at = "2025-01-01", Updated_at = "2025-01-01"
                },
                new FieldMaster {
                    Field_id = 11, Field_code = "LOCATION", Field_name = "保管場所",
                    Data_type = "TEXT", Control_type = "DROPDOWN", Is_active = 1,
                    Created_at = "2025-01-01", Updated_at = "2025-01-01"
                },
                new FieldMaster {
                    Field_id = 12, Field_code = "MEMO", Field_name = "備考",
                    Data_type = "TEXT", Control_type = "INPUT", Is_active = 1,
                    Created_at = "2025-01-01", Updated_at = "2025-01-01"
                }
            );

            modelBuilder.Entity<ItemCategory>().HasData(
               new ItemCategory
               {
                   Item_category_id = 1,
                   Item_category_name = "副資材",
                   Created_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                   Updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
               },
               new ItemCategory
               {
                   Item_category_id = 2, Item_category_name = "副原料",
                   Created_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                   Updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
               },
               new ItemCategory
               {
                   Item_category_id = 3, Item_category_name = "格外品",
                   Created_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                   Updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
               },
               new ItemCategory
               {
                   Item_category_id = 4,
                   Item_category_name = "半製品",
                   Created_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                   Updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
               },
               new ItemCategory
               {
                   Item_category_id = 5,
                   Item_category_name = "中間品",
                   Created_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                   Updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
               }
               );


            modelBuilder.Entity<ItemUnit>().HasData(
                new ItemUnit
                {
                    Item_unit_id = 1,
                    Item_unit_code = "KG",
                    item_unit_name = "kg",
                    Unit_category = 1,
                    Created_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                },
                new ItemUnit
                {
                    Item_unit_id = 2,
                    Item_unit_code = "TON",
                    item_unit_name = "t",
                    Unit_category = 1,
                    Created_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                },
                new ItemUnit
                {
                    Item_unit_id=3,
                    Item_unit_code = "HON",
                    item_unit_name = "本",
                    Unit_category = 2,
                    Created_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                },
                new ItemUnit
                {
                    Item_unit_id = 4,
                    Item_unit_code = "MAI",
                    item_unit_name = "枚",
                    Unit_category = 2,
                    Created_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                },
                new ItemUnit
                {
                    Item_unit_id = 5,
                    Item_unit_code = "KAN",
                    item_unit_name = "缶",
                    Unit_category = 2,
                    Created_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                },
                new ItemUnit
                {
                    Item_unit_id = 6,
                    Item_unit_code = "TAI",
                    item_unit_name = "袋",
                    Unit_category = 2,
                    Created_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                });

            // LedgerItem関連
            modelBuilder.Entity<LedgerItem>(entity =>
            {
                entity.HasKey(li => li.Ledger_item_id);

                // --- ItemType (1) - LedgerItem (多) ---
                entity.HasOne(li => li.ItemType)
                      .WithMany(it => it.LedgerItems)
                      .HasForeignKey(li => li.Item_type_id)
                      .OnDelete(DeleteBehavior.Restrict);

                // --- Location (1) - LedgerItem (多) ---
                entity.HasOne(li => li.Location)
                      .WithMany(loc => loc.LedgerItems)
                      .HasForeignKey(li => li.Location_id)
                      .OnDelete(DeleteBehavior.Restrict);

                // --- LedgerItem (1) - Tag (多) ---
                entity.HasMany(li => li.Tags)
                      .WithOne(t => t.LedgerItem)
                      .HasForeignKey(t => t.Ledger_item_id)
                      .IsRequired(false);

                // --- LedgerItem (1) - InventoryResult (多) ---
                entity.HasMany(li => li.InventoryResults)
                      .WithOne(ir => ir.LedgerItem)
                      .HasForeignKey(ir => ir.Ledger_item_id)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(li => li.Winder)
                      .WithMany(loc => loc.LedgerItems)
                      .HasForeignKey(li => li.Winder_id)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Winder>().HasData(
               new Winder
               {
                   Winder_id = 1,
                   Winder_name = "2号機",
                   Created_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                   Updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
               },
               new Winder
               {
                   Winder_id = 2,
                   Winder_name = "Bスリ B",
                   Created_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                   Updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
               },
               new Winder
               {
                   Winder_id = 3,
                   Winder_name = "Bスリ F",
                   Created_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                   Updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
               },
               new Winder
               {
                   Winder_id = 4,
                   Winder_name = "3号機 No.1",
                   Created_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                   Updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
               },
               new Winder
               {
                   Winder_id = 5,
                   Winder_name = "3号機 No.2",
                   Created_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                   Updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
               },
               new Winder
               {
                   Winder_id = 6,
                   Winder_name = "4号機 No.1",
                   Created_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                   Updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
               },
               new Winder
               {
                   Winder_id = 7,
                   Winder_name = "4号機 No.2",
                   Created_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                   Updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
               },
               new Winder
               {
                   Winder_id = 8,
                   Winder_name = "その他",
                   Created_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                   Updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
               });

            modelBuilder.Entity<TagStatusType>().HasData(
                new TagStatusType
                {
                    Tag_status_id = 1,
                    Status_code = "UNASSIGNED",
                    Status_name = "未使用",
                    Created_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                },
                new TagStatusType
                {
                    Tag_status_id = 2,
                    Status_code = "ATTACHED",
                    Status_name = "紐づけ済み",
                    Created_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                },
                new TagStatusType
                {
                    Tag_status_id = 3,
                    Status_code = "DETACHED",
                    Status_name = "紐づけ解除済み",
                    Created_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                },
                new TagStatusType
                {
                    Tag_status_id = 4,
                    Status_code = "DUSABLED",
                    Status_name = "無効",
                    Created_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                });

            modelBuilder.Entity<TagEventType>().HasData(
                new TagEventType
                {
                    Tag_event_id = 1,
                    Event_code = "REGISTERED",
                    Event_name = "登録",
                    Created_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                },
                new TagEventType
                {
                    Tag_event_id = 2,
                    Event_code = "ATTACH",
                    Event_name = "紐づけ",
                    Created_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                },
                new TagEventType
                {
                    Tag_event_id = 3,
                    Event_code = "DETACH",
                    Event_name = "紐づけ解除",
                    Created_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                },
                new TagEventType
                {
                    Tag_event_id = 4,
                    Event_code = "DISABLED",
                    Event_name = "無効",
                    Created_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                });

            modelBuilder.Entity<ProcessType>().HasData(
                new ProcessType
                {
                    Process_type_id = 1,
                    Process_code = "USE",
                    Process_name = "使用",
                    Created_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                },
                new ProcessType
                {
                    Process_type_id = 2,
                    Process_code = "SELL",
                    Process_name = "売却",
                    Created_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                },
                new ProcessType
                {
                    Process_type_id = 3,
                    Process_code = "CRUSH",
                    Process_name = "粉砕",
                    Created_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                },
                new ProcessType
                {
                    Process_type_id = 4,
                    Process_code = "DISPOSE",
                    Process_name = "廃棄",
                    Created_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                },
                new ProcessType
                {
                    Process_type_id = 5,
                    Process_code = "PROCESS",
                    Process_name = "加工",
                    Created_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                });

            modelBuilder.Entity<EventType>().HasData(
                new EventType
                {
                    Event_type_id = 1,
                    Event_code = "STOCK_IN",
                    Event_name = "入庫",
                    Created_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                },
                new EventType
                {
                    Event_type_id = 2,
                    Event_code = "STOCK_OUT",
                    Event_name = "出庫",
                    Created_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                },
                new EventType
                {
                    Event_type_id = 3,
                    Event_code = "MOVE",
                    Event_name = "保管場所移動",
                    Created_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                },
                new EventType
                {
                    Event_type_id = 4,
                    Event_code = "INVENTORY_STOCK_IN",
                    Event_name = "棚卸入庫(自動)",
                    Created_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                },
                new EventType
                {
                    Event_type_id = 5,
                    Event_code = "INVENTORY_STOCK_OUT",
                    Event_name = "棚卸出庫(自動)",
                    Created_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                },
                new EventType
                {
                    Event_type_id = 6,
                    Event_code = "INVENTORY_MOVE",
                    Event_name = "棚卸保管場所移動(自動)",
                    Created_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                },
                new EventType
                {
                    Event_type_id = 7,
                    Event_code = "EDIT",
                    Event_name = "編集",
                    Created_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                });


            //Tag関連
            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasKey(t => t.Tag_id);

                entity.HasIndex(t => t.Epc).IsUnique();

                entity.HasIndex(t => t.Ledger_item_id).IsUnique(false);

                entity.Property(t => t.Epc)
                    .IsRequired();

                entity.HasOne(t => t.LedgerItem)
                    .WithMany(li => li.Tags)
                    .HasForeignKey(t => t.Ledger_item_id)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(th => th.TagStatusType)
                    .WithMany(t => t.Tags)
                    .HasForeignKey(th => th.Tag_status_id)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            //TagHistory関連
            modelBuilder.Entity<TagHistory>(entity =>
            {
                entity.HasKey(th => th.Tag_history_id);

                // TagHistory - Tag (多 - 1)
                entity.HasOne(th => th.Tag)
                    .WithMany(t => t.TagHistories)
                    .HasForeignKey(th => th.Tag_id)
                    .OnDelete(DeleteBehavior.Cascade);

                // TagHistory - LedgerItem (多 - 1、null許可)
                entity.HasOne(th => th.LedgerItem)
                    .WithMany(t => t.TagHistories) 
                    .HasForeignKey(th => th.Ledger_item_id)
                    .OnDelete(DeleteBehavior.SetNull);

                // TagHistory - TagEventType(多い - 1)
                entity.HasOne(th => th.TagEventType)
                      .WithMany(t => t.TagHistories)
                      .HasForeignKey(th => th.Tag_event_id)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            //InventoryResult関連
            modelBuilder.Entity<InventoryResult>(entity =>
            {
                entity.HasKey(ir => ir.Inventory_result_id);

                // InventorySession (1) - InventoryResult (多)
                entity.HasOne(ir => ir.InventorySession)
                    .WithMany(isn => isn.InventoryResults)
                    .HasForeignKey(ir => ir.Inventory_session_id)
                    .OnDelete(DeleteBehavior.Cascade);

                // InventoryResultType (1) - InventoryResult (多)
                entity.HasOne(ir => ir.InventoryResultType)
                    .WithMany(irt => irt.InventoryResults)
                    .HasForeignKey(ir => ir.Inventory_result_type_id)
                    .OnDelete(DeleteBehavior.Restrict);

                // LedgerItem (1) - InventoryResult (多)
                entity.HasOne(ir => ir.LedgerItem)
                    .WithMany(li => li.InventoryResults)
                    .HasForeignKey(ir => ir.Ledger_item_id)
                    .OnDelete(DeleteBehavior.Restrict);

                // Tag (1) - InventoryResult (多)
                entity.HasOne(ir => ir.Tag)
                    .WithMany(t => t.InventoryResults)
                    .HasForeignKey(ir => ir.Tag_id)
                    .OnDelete(DeleteBehavior.Restrict);

                // SystemLocation (1) - InventoryResult (多)
                entity.HasOne(ir => ir.Location)
                    .WithMany(sl => sl.InventoryResults)
                    .HasForeignKey(ir => ir.System_location_id_at_scan)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            //InventoryResultType関連
            modelBuilder.Entity<InventoryResultType>(entity =>
            {
                entity.HasKey(irt => irt.Inventory_result_type_id);
            });

            //InventorySession関連
            modelBuilder.Entity<InventorySession>(entity =>
            {
                entity.HasKey(isn => isn.Inventory_session_id);

                // Location (1) - InventorySession (多)
                entity.HasOne(isn => isn.Location)
                    .WithMany(loc => loc.InventorySessions)
                    .HasForeignKey(isn => isn.Location_id)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            //Location関連
            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(irt => irt.Location_id);
            });

            //Stock関連
            modelBuilder.Entity<Stock>(entity =>
            {
                entity.HasKey(s => s.Stock_id);

                entity.Property(s => s.Created_at)
                    .IsRequired();

                entity.Property(s => s.Updated_at)
                    .IsRequired();

                // ItemType (1) - Stock (N)
                entity.HasOne(s => s.ItemType)
                    .WithMany(it => it.Stocks)
                    .HasForeignKey(s => s.Item_type_id)
                    .OnDelete(DeleteBehavior.Restrict);

                // Location (1) - Stock (N)
                entity.HasOne(s => s.Location)
                    .WithMany(l => l.Stocks)
                    .HasForeignKey(s => s.Location_id)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            //ItemType関連
            modelBuilder.Entity<ItemType>(entity =>
            {
                entity.HasKey(it => it.Item_type_id);

                entity.HasIndex(it => it.Item_type_code).IsUnique();

                entity.HasOne(it => it.Item_count_unit)
                      .WithMany(u => u.CountItemTypes) // ItemUnit 側にナビゲーションがなければ空
                      .HasForeignKey(it => it.Item_count_unit_id)
                      .IsRequired(false)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(it => it.Item_weight_unit)
                      .WithMany(u => u.WeightItemTypes)
                      .HasForeignKey(it => it.Item_weight_unit_id)
                      .IsRequired(false)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(it => it.ItemCategory)
                      .WithMany(c => c.ItemTypes)
                      .HasForeignKey(it => it.Item_category_id)
                      .OnDelete(DeleteBehavior.Restrict);
            });


            //ItemUnit関連
            modelBuilder.Entity<ItemUnit>(entity =>
            {
                entity.HasKey(irt => irt.Item_unit_id);
            });

            //ItemCategory関連
            modelBuilder.Entity<ItemCategory>(entity =>
            {
                entity.HasKey(irt => irt.Item_category_id);
            });

            //ItemTypeFieldSetting関連
            modelBuilder.Entity<ItemTypeFieldSetting>(entity =>
            {
                entity.HasKey(x => new { x.Item_type_id, x.Field_id });

                // ItemType - ItemTypeFieldSetting 
                entity.HasOne(it => it.ItemType)
                    .WithMany(t => t.ItemTypeFieldSettings)
                    .HasForeignKey(it => it.Item_type_id)
                    .OnDelete(DeleteBehavior.Restrict);

                // FieldMaster - ItemTypeFieldSetting
                entity.HasOne(it => it.FieldMaster)
                    .WithMany(d => d.ItemTypeFieldSettings)
                    .HasForeignKey(it => it.Field_id)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            //FieldMaster関連
            modelBuilder.Entity<FieldMaster>(entity =>
            {
                entity.HasKey(irt => irt.Field_id);
            });

            //LedgerItemEvent関連
            modelBuilder.Entity<LedgerItemEvent>(entity =>
            {
                entity.HasKey(th => th.Event_id);

                // --- LedgerItem (1) - LedgerItemEvent (多) ---
                entity.HasOne(li => li.LedgerItem)
                    .WithMany(loc => loc.LedgerItemEvent)
                    .HasForeignKey(li => li.Ledger_item_id)
                    .OnDelete(DeleteBehavior.Restrict);

                // --- EventType (1) - LedgerItemEvent (多) ---
                entity.HasOne(li => li.EventType)
                      .WithMany(t => t.LedgerItemEvent)
                      .HasForeignKey(t => t.Event_type_id)
                      .OnDelete(DeleteBehavior.SetNull);

                // --- ProcessType (1) - LedgerItemEvent (多) ---
                entity.HasOne(li => li.ProcessType)
                      .WithMany(ir => ir.LedgerItemEvent)
                      .HasForeignKey(ir => ir.Process_type_id)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            //EventType関連
            modelBuilder.Entity<EventType>(entity =>
            {
                entity.HasKey(irt => irt.Event_type_id);
            });

            //ProcessType関連
            modelBuilder.Entity<ProcessType>(entity =>
            {
                entity.HasKey(irt => irt.Process_type_id);
            });

            //CsvTaskType関連
            modelBuilder.Entity<CsvTaskType>(entity =>
            {
                entity.HasKey(irt => irt.Csv_task_type_id);
            });

            //CsvHistory関連
            modelBuilder.Entity<CsvHistory>(entity =>
            {
                entity.HasKey(irt => irt.Csv_history_id);

                // --- CsvTaskType (1) - CsvHistory (多) ---
                entity.HasOne(li => li.CsvTaskType)
                      .WithMany(ir => ir.CsvHistory)
                      .HasForeignKey(ir => ir.Csv_task_type_id)
                      .OnDelete(DeleteBehavior.Restrict);

            });

            //Winder関連
            modelBuilder.Entity<Winder>(entity =>
            {
                entity.HasKey(irt => irt.Winder_id);
            });

            //TagStatusType関連
            modelBuilder.Entity<TagStatusType>(entity =>
            {
                entity.HasKey(irt => irt.Tag_status_id);
            });

            //TagEventType関連
            modelBuilder.Entity<TagEventType>(entity =>
            {
                entity.HasKey(irt => irt.Tag_event_id);
            });
        }
    }
}