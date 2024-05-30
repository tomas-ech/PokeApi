import { MigrationInterface, QueryRunner } from "typeorm";

export class AddedPokemonStats1716988410264 implements MigrationInterface {
    name = 'AddedPokemonStats1716988410264'

    public async up(queryRunner: QueryRunner): Promise<void> {
        await queryRunner.query(`ALTER TABLE \`pokemon\` ADD \`health\` int NOT NULL DEFAULT '0'`);
        await queryRunner.query(`ALTER TABLE \`pokemon\` ADD \`attack\` int NOT NULL DEFAULT '0'`);
        await queryRunner.query(`ALTER TABLE \`pokemon\` ADD \`special_attack\` int NOT NULL DEFAULT '0'`);
        await queryRunner.query(`ALTER TABLE \`pokemon\` ADD \`defense\` int NOT NULL DEFAULT '0'`);
        await queryRunner.query(`ALTER TABLE \`pokemon\` ADD \`special_defense\` int NOT NULL DEFAULT '0'`);
        await queryRunner.query(`ALTER TABLE \`pokemon\` ADD \`speed\` int NOT NULL DEFAULT '0'`);
    }

    public async down(queryRunner: QueryRunner): Promise<void> {
        await queryRunner.query(`ALTER TABLE \`pokemon\` DROP COLUMN \`speed\``);
        await queryRunner.query(`ALTER TABLE \`pokemon\` DROP COLUMN \`special_defense\``);
        await queryRunner.query(`ALTER TABLE \`pokemon\` DROP COLUMN \`defense\``);
        await queryRunner.query(`ALTER TABLE \`pokemon\` DROP COLUMN \`special_attack\``);
        await queryRunner.query(`ALTER TABLE \`pokemon\` DROP COLUMN \`attack\``);
        await queryRunner.query(`ALTER TABLE \`pokemon\` DROP COLUMN \`health\``);
    }

}
