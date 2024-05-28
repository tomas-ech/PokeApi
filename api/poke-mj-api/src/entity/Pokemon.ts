import { Entity, PrimaryGeneratedColumn, Column } from "typeorm"
import { TypePokemonEnum } from "../functions/enums"

@Entity()
export class Pokemon {

    @PrimaryGeneratedColumn()
    id: number
    
    @Column()
    pokedexID: number

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


    @Column()
    nombre: string
}
