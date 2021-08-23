import Attachment from "./Attachment";

export default interface Weapon{
    name: string;
    category: string;
    attachments: Attachment[];
}