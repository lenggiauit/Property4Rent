 
import { CreatedBy } from "./createdBy"; 
import { Language } from "./language";
import { PropertyType } from "./propertyType";

export type Property =
    {
        id: any, 
        name: any,
        image: any,
        description: any,
        package: any,
        isArchived: boolean,
        totalRows: number,
        propertyType: PropertyType,
        
    }