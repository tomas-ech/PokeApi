import { MigrationInterface, QueryRunner } from "typeorm";

export class AddedAllTypes1716989484037 implements MigrationInterface {
    name = 'AddedAllTypes1716989484037'

    public async up(queryRunner: QueryRunner): Promise<void> {
        await queryRunner.query(`ALTER TABLE \`pokemon\` CHANGE \`type1\` \`type1\` enum ('None', 'Grass', 'Fire', 'Water', 'Ground', 'Rock', 'Fairy', 'Psychic', 'Bug', 'Dragon', 'Dark', 'Fighting', 'Ice', 'Steel', 'Normal', 'Poison', 'Electric', 'Ghost', 'Flying') NOT NULL`);
        await queryRunner.query(`ALTER TABLE \`pokemon\` CHANGE \`type2\` \`type2\` enum ('None', 'Grass', 'Fire', 'Water', 'Ground', 'Rock', 'Fairy', 'Psychic', 'Bug', 'Dragon', 'Dark', 'Fighting', 'Ice', 'Steel', 'Normal', 'Poison', 'Electric', 'Ghost', 'Flying') NOT NULL DEFAULT 'None'`);
    }

    public async down(queryRunner: QueryRunner): Promise<void> {
        await queryRunner.query(`ALTER TABLE \`pokemon\` CHANGE \`type2\` \`type2\` enum ('0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '10', '11', '12', '13', '14', '15', '16', '17', '18') NOT NULL DEFAULT '0'`);
        await queryRunner.query(`ALTER TABLE \`pokemon\` CHANGE \`type1\` \`type1\` enum ('0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '10', '11', '12', '13', '14', '15', '16', '17', '18') NOT NULL`);
    }

}
