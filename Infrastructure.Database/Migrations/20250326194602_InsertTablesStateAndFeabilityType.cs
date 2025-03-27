using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InsertTablesStateAndFeabilityType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tb_states",
                columns: new[] { "id_state", "uf" },
                values: new object[,]
                {
                    { Guid.Parse("2607975a-d927-400a-a8f0-8d1ba8a0a214"), "AC" },
                    { Guid.Parse("1c6cf124-e851-4a3e-b82a-be710eaf893c"), "AL" },
                    { Guid.Parse("bac568ae-9b87-47c4-a42f-466e4f33a7dc"), "AP" },
                    { Guid.Parse("973d96e4-b4cf-4791-ac35-cd91b77f2c25"), "AM" },
                    { Guid.Parse("c924ede6-ef47-4a43-8c64-f16d1551240e"), "BA" },
                    { Guid.Parse("fc50e64e-e64e-4af3-b26f-313dcac9b59e"), "CE" },
                    { Guid.Parse("1c92aabf-41f1-43d0-b024-5b28f1c9e188"), "DF" },
                    { Guid.Parse("5a89b1ac-a7b5-4ca9-8a7d-e24133bfb6ae"), "ES" },
                    { Guid.Parse("23d9e992-e724-47bf-aaf1-c3ed29fa6fc7"), "GO" },
                    { Guid.Parse("b5c7c833-77ea-4445-acce-3419fced5fd1"), "MA" },
                    { Guid.Parse("a13c0da5-176d-4dcb-9f29-12cfed355fc9"), "MT" },
                    { Guid.Parse("8fe1aaea-ed4a-4982-b504-eb86d29dc0ff"), "MS" },
                    { Guid.Parse("b26b6bcf-7c40-4ceb-9bc6-a08c3210968a"), "MG" },
                    { Guid.Parse("0873bf29-383a-40b9-b0e2-938e016aaa6d"), "PA" },
                    { Guid.Parse("9ad66602-ef84-4969-ac77-1dcdffb9601f"), "PB" },
                    { Guid.Parse("a6d94e3f-5717-4851-b131-4e8dceb83400"), "PR" },
                    { Guid.Parse("2fd30b9c-6d5b-4553-833a-058f542e7195"), "PE" },
                    { Guid.Parse("75125b90-6c4b-4f91-b824-53c8f334acb9"), "PI" },
                    { Guid.Parse("856f02de-182e-4e5f-ab58-9e8c96aa53ca"), "RJ" },
                    { Guid.Parse("3e1c05cf-1f71-4a4e-b446-bbff44b39338"), "RN" },
                    { Guid.Parse("5531a471-6ee0-464f-8963-3fa461860b53"), "RS" },
                    { Guid.Parse("c54286e7-e795-4d77-b05e-0f1698fc4873"), "RO" },
                    { Guid.Parse("8c8de21b-abc1-448a-937c-f16143c23b79"), "RR" },
                    { Guid.Parse("e1f6f8f4-c02c-46c7-bfb7-4ef1743fc7a5"), "SC" },
                    { Guid.Parse("c3ea622a-a63f-4d1a-9070-faab42f5a340"), "SP" },
                    { Guid.Parse("87835c9b-89ac-4380-be9d-ffad4ce1a727"), "SE" },
                    { Guid.Parse("b0781524-7c8f-4679-b6e9-e0a082dcb920"), "TO" }
                });

            migrationBuilder.InsertData(
                table: "tb_feasibility_types",
                columns: new[] { "id_feasibility_type", "type" },
                values: new object[,]
                {
                    { Guid.Parse("61dd0e8e-db55-4f53-9180-7a3847533246"), "Cidade" },
                    { Guid.Parse("c7ce8e12-30ac-43fd-b15f-07a22ee6f27c"), "Estado" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var stateIds = new List<Guid>
            {
                Guid.Parse("2607975a-d927-400a-a8f0-8d1ba8a0a214"),
                Guid.Parse("1c6cf124-e851-4a3e-b82a-be710eaf893c"),
                Guid.Parse("bac568ae-9b87-47c4-a42f-466e4f33a7dc"),
                Guid.Parse("973d96e4-b4cf-4791-ac35-cd91b77f2c25"),
                Guid.Parse("c924ede6-ef47-4a43-8c64-f16d1551240e"),
                Guid.Parse("fc50e64e-e64e-4af3-b26f-313dcac9b59e"),
                Guid.Parse("1c92aabf-41f1-43d0-b024-5b28f1c9e188"),
                Guid.Parse("5a89b1ac-a7b5-4ca9-8a7d-e24133bfb6ae"),
                Guid.Parse("23d9e992-e724-47bf-aaf1-c3ed29fa6fc7"),
                Guid.Parse("b5c7c833-77ea-4445-acce-3419fced5fd1"),
                Guid.Parse("a13c0da5-176d-4dcb-9f29-12cfed355fc9"),
                Guid.Parse("8fe1aaea-ed4a-4982-b504-eb86d29dc0ff"),
                Guid.Parse("b26b6bcf-7c40-4ceb-9bc6-a08c3210968a"),
                Guid.Parse("0873bf29-383a-40b9-b0e2-938e016aaa6d"),
                Guid.Parse("9ad66602-ef84-4969-ac77-1dcdffb9601f"),
                Guid.Parse("a6d94e3f-5717-4851-b131-4e8dceb83400"),
                Guid.Parse("2fd30b9c-6d5b-4553-833a-058f542e7195"),
                Guid.Parse("75125b90-6c4b-4f91-b824-53c8f334acb9"),
                Guid.Parse("856f02de-182e-4e5f-ab58-9e8c96aa53ca"),
                Guid.Parse("3e1c05cf-1f71-4a4e-b446-bbff44b39338"),
                Guid.Parse("5531a471-6ee0-464f-8963-3fa461860b53"),
                Guid.Parse("c54286e7-e795-4d77-b05e-0f1698fc4873"),
                Guid.Parse("8c8de21b-abc1-448a-937c-f16143c23b79"),
                Guid.Parse("e1f6f8f4-c02c-46c7-bfb7-4ef1743fc7a5"),
                Guid.Parse("c3ea622a-a63f-4d1a-9070-faab42f5a340"),
                Guid.Parse("87835c9b-89ac-4380-be9d-ffad4ce1a727"),
                Guid.Parse("b0781524-7c8f-4679-b6e9-e0a082dcb920")
            };

            foreach (var id in stateIds)
            {
                migrationBuilder.DeleteData(
                    table: "tb_states",
                    keyColumn: "id_state",
                    keyValue: id
                );
            }

            var feasibilityTypeIds = new List<Guid>
            {
                Guid.Parse("61dd0e8e-db55-4f53-9180-7a3847533246"),
                Guid.Parse("c7ce8e12-30ac-43fd-b15f-07a22ee6f27c")
            };

            foreach (var id in feasibilityTypeIds)
            {
                migrationBuilder.DeleteData(
                    table: "tb_feasibility_types",
                    keyColumn: "id_feasibility_type",
                    keyValue: id
                );
            }
        }
    }
}
