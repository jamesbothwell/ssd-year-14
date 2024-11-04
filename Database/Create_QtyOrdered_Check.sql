use CA

alter table WeddingListPurchase
add check (QtyOrdered <= QtyRequired)