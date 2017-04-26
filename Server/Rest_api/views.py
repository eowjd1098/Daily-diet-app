from django.shortcuts import render

# Create your views here.
from rest_framework import serializers, mixins
from rest_framework.generics import GenericAPIView


from Rest_api.models import Member

class MemberSerializer(serializers.ModelSerializer):
    class Meta:
        model = Member
        fields = '__all__'

class member_api(GenericAPIView,
                 mixins.ListModelMixin,
                 mixins.CreateModelMixin,
                 ):
    queryset = Member.objects.all()
    serializer_class = MemberSerializer

    def get(self, request, *args, **kwargs):
        return self.list(request, *args, **kwargs)

    def post(self, request, *args, **kwargs):
        return self.create(request, *args, **kwargs)
