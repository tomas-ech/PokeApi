import { MigrationInterface, QueryRunner } from "typeorm";

export class InitDatabase1716924080608 implements MigrationInterface {
    name = 'InitDatabase1716924080608'

    public async up(queryRunner: QueryRunner): Promise<void> {
        await queryRunner.query(`CREATE TABLE \`user\` (\`id\` int NOT NULL AUTO_INCREMENT, \`nombre\` varchar(255) NOT NULL, PRIMARY KEY (\`id\`)) ENGINE=InnoDB`);
        await queryRunner.query(`ALTER TABLE \`pokemon\` ADD \`pokedexID\` int NOT NULL`);
        await queryRunner.query(`ALTER TABLE \`pokemon\` ADD \`type1\` enum ('Hierba', 'Fuego') NOT NULL`);
        await queryRunner.query(`ALTER TABLE \`pokemon\` ADD \`type2\` enum ('Hierba', 'Fuego') NOT NULL`);
        await queryRunner.query(`ALTER TABLE \`user_collection\` ADD CONSTRAINT \`FK_ea2e8bed8ef935e94917b71d220\` FOREIGN KEY (\`userId\`) REFERENCES \`user\`(\`id\`) ON DELETE NO ACTION ON UPDATE NO ACTION`);
        await queryRunner.query(`ALTER TABLE \`user_collection\` ADD CONSTRAINT \`FK_6f5889359d7c14c5ca75754673e\` FOREIGN KEY (\`pokemonId\`) REFERENCES \`pokemon\`(\`id\`) ON DELETE NO ACTION ON UPDATE NO ACTION`);
    }

    public async down(queryRunner: QueryRunner): Promise<void> {
        await queryRunner.query(`ALTER TABLE \`user_collection\` DROP FOREIGN KEY \`FK_6f5889359d7c14c5ca75754673e\``);
        await queryRunner.query(`ALTER TABLE \`user_collection\` DROP FOREIGN KEY \`FK_ea2e8bed8ef935e94917b71d220\``);
        await queryRunner.query(`ALTER TABLE \`pokemon\` DROP COLUMN \`type2\``);
        await queryRunner.query(`ALTER TABLE \`pokemon\` DROP COLUMN \`type1\``);
        await queryRunner.query(`ALTER TABLE \`pokemon\` DROP COLUMN \`pokedexID\``);
        await queryRunner.query(`DROP TABLE \`user\``);
    }

}
