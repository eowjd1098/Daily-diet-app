from django.db import models
# Create your models here.

class Member(models.Model):
    member_id = models.CharField(max_length=100)
    member_pw = models.CharField(max_length=100)
    member_name = models.CharField(max_length=100)
    member_age = models.CharField(max_length=20)
    member_gender = models.CharField(max_length=20)