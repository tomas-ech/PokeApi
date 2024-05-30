import { Entity, PrimaryGeneratedColumn, Column } from "typeorm"
import { TypePokemonEnum } from "../functions/enums"

@Entity()
export class Pokemon {

    @PrimaryGeneratedColumn()
    id: number
    
    @Column()
    pokedexID: number

    @Column()
    nombre: string

    @Column({
        type: "enum",
        enum: TypePokemonEnum,
        nullable: false,
    })
    type1: TypePokemonEnum

    @Column({
        type: "enum",
        enum: TypePokemonEnum,
        nullable: false,
        default: TypePokemonEnum.NONE,
    })
    type2: TypePokemonEnum

    @Column({
        default: 0
    })
    health: number

    @Column({
        default: 0
    })
    attack: number

    @Column({
        default: 0
    })
    special_attack: number

    @Column({
        default: 0
    })
    defense: number

    @Column({
        default: 0
    })
    special_defense: number

    @Column({
        default: 0
    })
    speed: number
}
