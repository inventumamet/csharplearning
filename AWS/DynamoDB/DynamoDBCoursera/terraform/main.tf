


resource "aws_dynamodb_table" "lab1-dynamodb-table" {
  name           = "Lab1Table"
  billing_mode   = "PAY_PER_REQUEST"
  read_capacity  = 20
  write_capacity = 20
  hash_key       = "DragonName"
  range_key      = "DragonType"

  attribute {
    name = "DragonName"
    type = "S"
  }

  attribute {
    name = "DragonType"
    type = "S"
  }

  attribute {
    name = "Description"
    type = "S"
  }

  attribute {
    name = "Attack"
    type = "S"
  }


  attribute {
    name = "Defense"
    type = "S"
  }


  ttl {
    attribute_name = "TimeToExist"
    enabled        = false
  }

  global_secondary_index {
    name               = "DragonNameAttackIndex"
    hash_key           = "DragonName"
    range_key          = "Attack"
    write_capacity     = 10
    read_capacity      = 10
    projection_type    = "INCLUDE"
    non_key_attributes = ["UserId"]
  }

  global_secondary_index {
    name               = "DragonNameDefenseIndex"
    hash_key           = "DragonName"
    range_key          = "Defense"
    write_capacity     = 10
    read_capacity      = 10
    projection_type    = "INCLUDE"
    non_key_attributes = ["UserId"]
  }

  global_secondary_index {
    name               = "DragonTypeAttackIndex"
    hash_key           = "DragonType"
    range_key          = "Attack"
    write_capacity     = 10
    read_capacity      = 10
    projection_type    = "INCLUDE"
    non_key_attributes = ["UserId"]
  }

  global_secondary_index {
    name               = "DragonTypeDefenseIndex"
    hash_key           = "DragonType"
    range_key          = "Defense"
    write_capacity     = 10
    read_capacity      = 10
    projection_type    = "INCLUDE"
    non_key_attributes = ["UserId"]
  }

  global_secondary_index {
    name               = "DragonNameDescriptionIndex"
    hash_key           = "DragonName"
    range_key          = "Description"
    write_capacity     = 10
    read_capacity      = 10
    projection_type    = "INCLUDE"
    non_key_attributes = ["UserId"]
  }

  tags = {
    Name        = "dynamodb-table-lab-1"
  }
}